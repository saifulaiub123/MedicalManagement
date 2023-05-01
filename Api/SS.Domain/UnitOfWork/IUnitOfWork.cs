using SS.Domain.DBModel;
using SS.Domain.IRepository;

namespace SS.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Repositories
        IUserProfileRepository UserProfileRepository { get; }
        #endregion
        void ClearChangeTracker();
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
