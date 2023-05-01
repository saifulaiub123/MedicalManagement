
using SS.Domain.DBModel;

namespace SS.Domain.IRepository
{
    public interface IRoleRepository
    {
        Task<Role> GetById(int id);
    }
}
