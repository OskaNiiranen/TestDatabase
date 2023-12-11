using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace webAPI.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add configuration settings
            builder.Configuration.AddJsonFile("appsettings.json");

            // Register your database context
            builder.Services.AddDbContext<TestDatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TestDatabaseContext")
                    ?? throw new InvalidOperationException("Connection string 'TestDatabaseContext' not found.")));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Redirect HTTP requests to HTTPS
            app.UseHttpsRedirection();

            // Endpoint configuration
            app.Map("/testitaulu", app =>
            {
                app.Run(async context =>
                {
                    // Your logic for handling requests to /testitaulu
                    await context.Response.WriteAsync("Handling /testitaulu requests...");
                });
            });

            app.Run();
        }
    }

    // Your database context class here (e.g., TestDatabaseContext)
    // and other classes related to your application
}
