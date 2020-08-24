using System;
using Microsoft.Extensions.Configuration;

namespace Identity.Infrastructure.Helpers
{
    public class App
    {
        public static string EnvironmentName
        {
            get
            {
                return Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ??
                    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            }
        }

        public static IConfiguration Configuration
        {
            get
            {
                var basePath = AppContext.BaseDirectory;
                var builder = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{EnvironmentName}.json", true)
                    .AddEnvironmentVariables();
                var configuration = builder.Build();
                return configuration;
            }
        }
    }
}