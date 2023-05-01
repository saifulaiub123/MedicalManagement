using SS.Application.IService;
using SS.Domain.DBModel;
using SS.Domain.IRepository;
using SS.Domain.Model;
using SS.Infrastructure.DBContext;

namespace SS.Application.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> GetById(int id)
        {
            return await _roleRepository.GetById(id);
        }
    }
}
