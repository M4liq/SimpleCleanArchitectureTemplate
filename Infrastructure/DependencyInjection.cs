using Application.Common.Interfaces.Settings;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

  public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.InitializeConfiguration(configuration);
        }
        
        private static void InitializeConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var someSetting = configuration.GetSection("SomeSetting").Get<SomeSetting>();
            
            services.AddSingleton<ISomeSetting>(someSetting);
        }
    }