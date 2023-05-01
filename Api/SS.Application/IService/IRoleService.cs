
using SS.Domain.DBModel;

namespace SS.Application.IService
{
    public interface IRoleService
    {
        Task<Role> GetById(int id);
    }
}
