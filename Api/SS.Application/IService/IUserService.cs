using SS.Domain.Model;
using SS.Domain.ViewModel;

namespace SS.Application.IService
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserById(int id);
        Task UpdateUser(UserModel user);
        Task Delete(int id);
        Task<bool> IsAdmin(int userId);
        Task<bool> CanViewOrEdit(int userId);
    }
}
