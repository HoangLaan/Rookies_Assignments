using MVC.NetAssignment02.BusinessLogic;
using MVC.NetAssignment02.Model.Reposiroty;

namespace MVC.NetAssignment02.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);
			var services = builder.Services;
			// Add services to the container.
			services.AddControllersWithViews();

			services.AddSingleton<IPersonBusinessLogic, PersonBusinessLogic>();
            services.AddSingleton<IPersonRepository, PersonRepository>();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}