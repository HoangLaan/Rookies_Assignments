public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var currentDate = DateTime.Now.ToString("dd_MM_yyyy");
        var filePath = $"{currentDate}.txt";

        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            //Print Current Time to know when we run
            await writer.WriteLineAsync($"Time now: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")}");
            await writer.WriteLineAsync($"Schema: {context.Request.Scheme}");
            await writer.WriteLineAsync($"Host: {context.Request.Host}");
            await writer.WriteLineAsync($"Path: {context.Request.Path}");
            await writer.WriteLineAsync($"QueryString: {context.Request.QueryString}");

            context.Request.EnableBuffering();

            if (context.Request.Body.CanRead)
            {
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;
                await writer.WriteLineAsync($"Request Body: {body}");
            }

            await writer.WriteLineAsync("------");
        }

        await _next(context);
    }
}

public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.UseMiddleware<LoggingMiddleware>();

    }
}