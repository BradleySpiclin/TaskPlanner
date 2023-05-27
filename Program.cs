using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Win32;
using System.ComponentModel;
using TaskPlanner.Data;
using TaskPlanner.Data.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace TaskPlanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


    /*      Retrieves the passwordless database connection string from the appsettings.Development.json 
     *      file for local development, or from the environment variables for hosted production scenarios.
            Registers the Entity Framework Core DbContext class with the.NET dependency injection container.*/
            var connection = String.Empty;
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
                connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            }
            else
            {
                connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
            }

            // DbContext configuration
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            // Add the tasks service
            builder.Services.AddScoped<ITaskService, TaskService>();

            var app = builder.Build();

            // Seed database
            AppDbInitializer.Seed(app);

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
                pattern: "{controller=Tasks}/{action=Index}/{id?}");

            app.Run();
        }
    }
}