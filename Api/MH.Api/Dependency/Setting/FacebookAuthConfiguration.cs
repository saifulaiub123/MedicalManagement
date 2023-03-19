using System.Configuration;
using MH.Domain.Constant;
using MH.Domain.Settings;

namespace MH.Api.Dependency.Setting
{
    public static class FacebookAuthConfiguration
    {
        public static IServiceCollection AddFacebookAuthSettingService(this IServiceCollection services, IConfiguration configuration)
        {
            var facebookAuthSetting = configuration.GetSection(ConfigOptions.FacebookAuthConfigName).Get<FacebookAuthSetting>();
            services.AddSingleton(facebookAuthSetting);

            return services;    
        }
    }
}
