using SS.Api.Authentication;
using SS.Application.IService;
using SS.Application.Service;
using SS.Domain.DBModel;
using SS.Domain.IRepository;

namespace SS.Api.Dependency
{
    public static class ApplicationResolutionConfiguration
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<TokenHelper>();
            return services;
        }
    }
}
