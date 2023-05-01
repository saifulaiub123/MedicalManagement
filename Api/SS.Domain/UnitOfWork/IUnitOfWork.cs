using SS.Domain.DBModel;
using SS.Domain.IRepository;

namespace SS.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Repositories
        IPositionRepository PositionRepository { get; }
        IContactDetailsRepository ContactDetailsRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        #endregion
        void ClearChangeTracker();
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
