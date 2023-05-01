using SS.Domain.IEntity;

namespace SS.Domain.Model
{
    public class BaseViewModel<TId> : IBaseEntity<TId>
    {
        public TId? Id { get; set; }
    }
}
