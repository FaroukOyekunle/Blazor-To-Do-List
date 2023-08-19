using BlazorToDoList.App.Data;
using BlazorToDoList.App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BlazorToDoList.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Razor Pages
            services.AddRazorPages();

            // Add Server-Side Blazor
            services.AddServerSideBlazor()
                .AddCircuitOptions(options =>
                {
                    // Configure detailed errors from app settings
                    options.DetailedErrors = Convert.ToBoolean(Configuration["DetailedErrors"]);
                });

            // Register services
            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<IFileService, FileService>();
            services.AddScoped<IToDoService, ToDoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Use developer exception page for development environment
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Use exception handler for non-development environments
                app.UseExceptionHandler("/Error");

                // Configure HTTP Strict Transport Security (HSTS)
                app.UseHsts();
            }

            // Redirect HTTP requests to HTTPS
            app.UseHttpsRedirection();

            // Serve static files (wwwroot)
            app.UseStaticFiles();

            // Configure routing
            app.UseRouting();

            // Configure endpoints
            app.UseEndpoints(endpoints =>
            {
                // Map Blazor hub endpoint
                endpoints.MapBlazorHub();

                // Map fallback to _Host (Blazor)
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
