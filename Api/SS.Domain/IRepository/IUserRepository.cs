using SS.Domain.DBModel;
using SS.Domain.ViewModel;

namespace SS.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserById(int id);
        Task DeleteUserRole(UserRole userRole);
        Task AddUserRole(UserRole userRole);
        Task UpdateUserRole(UserRole userRole);
        //Task UpdateUser(ApplicationUser user);
    }
}
