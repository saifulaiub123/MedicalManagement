using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Domain.UnitOfWork;
using MH.Infrastructure.DBContext;
using MH.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Infrastructure.UnitOfWork
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IRepository<Script, int> _scriptRepository;
        public IRepository<ScriptHistory, int> _scriptHistoryRepository;
        public IRepository<ScriptUserPermission, int> _scriptUserPermissionRepository;

        public UnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #region Repositories

        private IUserProfileImageRepository _userProfileImageRepository;
        public IUserProfileImageRepository UserProfileImageRepository => _userProfileImageRepository ?? new UserProfileImageRepository(_dbContext);

        private ISongCategoryRepository _songCategoryRepository;
        public ISongCategoryRepository SongCategoryRepository => _songCategoryRepository ?? new SongCategoryRepository(_dbContext);

        private ICollaboratorRepository _collaboratorRepository;
        public ICollaboratorRepository CollaboratorRepository => _collaboratorRepository ?? new CollaboratorRepository(_dbContext);

        private ILyricsRepository _lyricsRepository;
        public ILyricsRepository LyricsRepository => _lyricsRepository ?? new LyricsRepository(_dbContext);

        private ISongRepository _songRepository;
        public ISongRepository SongRepository => _songRepository ?? new SongRepository(_dbContext);

        private IUserProfileRepository _userProfileRepository;
        public IUserProfileRepository UserProfileRepository => _userProfileRepository ?? new UserProfileRepository(_dbContext);

        private ICityRepository _cityRepository;
        public ICityRepository CityRepository => _cityRepository ?? new CityRepository(_dbContext);

        private IStateRepository _stateRepository;
        public IStateRepository StateRepository => _stateRepository ?? new StateRepository(_dbContext);

        private ICountryRepository _countryRepository;
        public ICountryRepository CountryRepository => _countryRepository ?? new CountryRepository(_dbContext);

        #endregion

        public IRepository<Script, int> ScriptRepository
        {
            get { return _scriptRepository = _scriptRepository ?? new Repository<Script, int>(_dbContext); }
        }
        public IRepository<ScriptHistory, int> ScriptHistoryRepository
        {
            get { return _scriptHistoryRepository = _scriptHistoryRepository ?? new Repository<ScriptHistory, int>(_dbContext); }
        }

        public IRepository<ScriptUserPermission, int> ScriptUserPermissionRepository
        {
            get { return _scriptUserPermissionRepository = _scriptUserPermissionRepository ?? new Repository<ScriptUserPermission, int>(_dbContext); }
        }
        
    }
}
