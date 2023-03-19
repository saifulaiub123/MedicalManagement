using Microsoft.Extensions.DependencyInjection;
using MH.Domain.IRepository;
using MH.Infrastructure.Repository;
using MH.Domain.DBModel;

namespace MH.Infrastructure.Dependency
{
    public static class RepositoryResolutionConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IUserProfileImageRepository, UserProfileImageRepository>();
            services.AddScoped<ISongCategoryRepository, SongCategoryRepository>();
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
            services.AddScoped<ILyricsRepository, LyricsRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            //services.AddScoped(typeof(Domain.IRepository.IRepository<typeof(Script),int>), typeof(Repository.Repository<typeof(Script),int>));
            
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IOtpRepository, OtpRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Server, int>, Repository<Server,int>>();
            services.AddScoped<IRepository<Permission, int>, Repository<Permission,int>>();
            services.AddScoped<IRepository<Script, int>, Repository<Script,int>>();
            services.AddScoped<IRepository<ScriptHistory, int>, Repository<ScriptHistory, int>>();
            services.AddScoped<IRepository<ScriptUserPermission, int>, Repository<ScriptUserPermission, int>>();
            #endregion
            return services;
        }
    }
}
