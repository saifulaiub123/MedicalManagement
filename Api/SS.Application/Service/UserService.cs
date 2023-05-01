using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SS.Application.IService;
using SS.Domain.DBModel;
using SS.Domain.IRepository;
using SS.Domain.Model;
using SS.Domain.ViewModel;
using SS.Domain.Constant;
using Microsoft.EntityFrameworkCore;
using SS.Application.Exception;
using SS.Domain.IEntity;

namespace SS.Application.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<ApplicationUser> userManager, ICurrentUser currentUser)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null) throw new RecordNotFound("User id not found");

            var data =  new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.UserProfile != null ? user.UserProfile.FirstName : "",
                LastName = user.UserProfile != null ? user.UserProfile.LastName : "",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserRoles = user.UserRoles.Select(y => y.Role.Name).ToList()
            };
            return data;
        }

        public async Task<bool> IsAdmin(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var isAdmin = (await _userManager.GetRolesAsync(user)).Where(x => x == RoleConst.ADMIN).FirstOrDefault();
            if (isAdmin != null) return true;

            return false;
        }
        public async Task<bool> CanViewOrEdit(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var isAdmin = (await _userManager.GetRolesAsync(user)).Where(x => x == RoleConst.ADMIN).FirstOrDefault();
            if (isAdmin != null) return true;

            if(userId == _currentUser.User.Id) return true;

            return false;
        }

        public async Task UpdateUser(UserModel user)
        {
            var exist = await _userRepository.GetUserById(user.Id);
            if (exist != null)
            {
                exist.PhoneNumber = user.PhoneNumber;
                foreach (var existUserRole in exist.UserRoles)
                {
                    if (!user.Roles.Any(x => x == existUserRole.RoleId))
                    {
                        await _userRepository.DeleteUserRole(existUserRole);
                    }
                }
                foreach (var updateRole in user.Roles)
                {
                    if (!exist.UserRoles.Any(x => x.RoleId == updateRole))
                    {
                        await _userRepository.AddUserRole(new UserRole() { UserId = user.Id, RoleId = updateRole });
                    }
                }
                await _userManager.UpdateAsync(exist);
            }
        }
        public async Task Delete(int id)
        {
            var exist = await _userRepository.GetUserById(id);
            if (exist != null)
            {
                exist.Status = 0;
                await _userManager.UpdateAsync(exist);
            }
        }
    }
}
