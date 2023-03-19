using MH.Application.Helper;
using MH.Application.IHelper;
using MH.Application.IService;
using MH.Application.Mail;
using MH.Application.Service;
using MH.Domain.Constant;
using MH.Domain.IEntity;
using MH.Domain.Settings;
using MH.Domain.UnitOfWork;
using MH.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace MH.Application.Dependency
{
    public static class ServiceResolutionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUserProfileImageService, UserProfileImageService>();
            services.AddScoped<ISongCategoryService, SongCategoryService>();
            services.AddScoped<ICollaboratorService, CollaboratorService>();
            services.AddScoped<ILyricsService, LyricsService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<IScriptService, ScriptService>();
            services.AddScoped<IScriptHistoryService, ScriptHistoryService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IScriptUserPermissionService, ScriptUserPermissionService>();
            services.AddScoped<IPowerShellHelper, PowerShellHelper>();
            services.AddScoped<IMailHelper, MailHelper>();
            #endregion

            return services;
        }
    }
}
