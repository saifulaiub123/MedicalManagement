using SS.Domain.DBModel;

namespace SS.Domain.IEntity
{
    public interface ICurrentUser
    {
        public ApplicationUser User { get; }
    }
}
