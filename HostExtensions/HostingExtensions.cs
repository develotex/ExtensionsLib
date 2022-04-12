using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace HostExtensions
{
    public static class HostingExtensions
    {
        public static void UseUserJsonFileConfig(this IHostBuilder host, string filePath = "appsettings.User.json", bool isOptional = true, string toggleConfigName = "DOTNET_LOAD_USER_CONFIG")
        {
            host.ConfigureAppConfiguration((ctx, cfg) =>
            {
                if(ctx.Configuration.GetValue<bool>(toggleConfigName))
                    cfg.AddJsonFile(filePath, isOptional);
            });
        }
    }
}
