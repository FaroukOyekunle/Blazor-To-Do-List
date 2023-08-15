
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BlazorToDoList.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Method to create a host builder
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // Use the default host builder
            Host.CreateDefaultBuilder(args)
                // Configure web host defaults
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Use the Startup class to configure the web host
                    webBuilder.UseStartup<Startup>();
                });
    }
}
