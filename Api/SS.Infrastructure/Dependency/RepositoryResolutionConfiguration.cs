using Microsoft.Extensions.DependencyInjection;
using SS.Domain.IRepository;
using SS.Infrastructure.Repository;
using SS.Domain.DBModel;

namespace SS.Infrastructure.Dependency
{
    public static class RepositoryResolutionConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            //services.AddScoped(typeof(Domain.IRepository.IRepository<typeof(Script),int>), typeof(Repository.Repository<typeof(Script),int>));
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
            return services;
        }
    }
}
