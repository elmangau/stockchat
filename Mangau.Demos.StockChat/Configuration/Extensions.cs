using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Mangau.Demos.StockChat.Configuration
{
    public static class Extensions
    {
        public static AppSettings AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.Get<AppSettings>();

            services.Configure<AppSettings>(configuration);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AppSettings>>().Value);

            return settings;
        }
    }
}
