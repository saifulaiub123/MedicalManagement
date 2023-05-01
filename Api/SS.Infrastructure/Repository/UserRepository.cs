using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Domain.DBModel;
using SS.Domain.IRepository;
using SS.Domain.ViewModel;
using SS.Infrastructure.DBContext;

namespace SS.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUserRole(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserRole(UserRole userRole)
        {
           _context.UserRoles.Remove(userRole);
           await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserById(int id)
        {
            return await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(x => x.UserProfile)
                .Include(x=> x.UserProfile.ContactDetails)
                .Include(x=> x.UserProfile.ContactDetails.ContactDataType)
                .Include(x=> x.UserProfile.ContactDetails.ContactType)
                .Include(x=> x.UserProfile.ContactDetails.ContactEntity)
                .Include(x => x.Position)
                .Where(x => x.Id == id && x.Status == 1)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateUserRole(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
