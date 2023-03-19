using MH.Domain.Constant;
using MH.Domain.Settings;

namespace MH.Api.Dependency.Setting
{
    public static class GoogleAuthConfiguration
    {
        public static IServiceCollection AddGoogleAuthSettingService(this IServiceCollection services, IConfiguration configuration)
        {
            var googleAuthSetting = configuration.GetSection(ConfigOptions.GoogleAuthConfigName).Get<GoogleAuthSetting>();
            services.AddSingleton(googleAuthSetting);

            return services;
        }
    }
}
