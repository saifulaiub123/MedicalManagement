using MH.Domain.DBModel;
using MH.Domain.IRepository;

namespace MH.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Repositories
        IRepository<Script, int> ScriptRepository { get; }
        IUserProfileImageRepository UserProfileImageRepository { get; }
        ISongCategoryRepository SongCategoryRepository { get; }
        ICollaboratorRepository CollaboratorRepository { get; }
        ILyricsRepository LyricsRepository { get; }
        ISongRepository SongRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        ICityRepository CityRepository { get; }
        IStateRepository StateRepository { get; }
        ICountryRepository CountryRepository { get; }
        IRepository<ScriptHistory, int> ScriptHistoryRepository { get; }
        IRepository<ScriptUserPermission, int> ScriptUserPermissionRepository { get; }
        #endregion
        void ClearChangeTracker();
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
