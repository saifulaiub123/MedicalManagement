using SS.Application.IService;
using SS.Application.Service;
using SS.Domain.Constant;
using SS.Domain.IEntity;
using SS.Domain.Settings;
using SS.Domain.UnitOfWork;
using SS.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace SS.Application.Dependency
{
    public static class ServiceResolutionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion

            return services;
        }
    }
}
