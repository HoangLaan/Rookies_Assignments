
using Asp.NetAPIAssignment02.WebApp.Repositories;
using Asp.NetAPIAssignment02.WebApp.Services;

namespace Asp.NetAPIAssignment02.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            // Add services to the container.

            services.AddControllers();
            services.AddAutoMapper(typeof(Program).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IPersonRepository, PersonRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
