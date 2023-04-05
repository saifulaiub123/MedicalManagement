using MH.Domain.DBModel;
using MH.Domain.IRepository;

namespace MH.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Repositories
        IUserProfileImageRepository UserProfileImageRepository { get; }
        IPositionRepository PositionRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        #endregion
        void ClearChangeTracker();
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
