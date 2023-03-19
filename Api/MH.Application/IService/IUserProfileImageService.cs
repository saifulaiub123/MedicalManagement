using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService
{
    public interface IUserProfileImageService
    {
        Task<List<UserProfileImageViewModel>> GetAll();
        Task<UserProfileImageViewModel> GetById(int id);
        Task Add(UserProfileImageModel userProfileImage);
        Task Update(UserProfileImageModel userProfileImage);
        Task Delete(int id); 
    }
}
