using SS.Domain.DBModel;
using SS.Domain.IRepository;
using SS.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace SS.Infrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Role> GetById(int id)
        {
            return await _context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
