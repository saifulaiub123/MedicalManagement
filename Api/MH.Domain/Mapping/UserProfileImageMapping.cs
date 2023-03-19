using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class UserProfileImageMapping : Profile
    {
        public UserProfileImageMapping()
        {
            CreateMap<UserProfileImage,UserProfileImageModel>().ReverseMap();
            CreateMap<UserProfileImage,UserProfileImageViewModel>().ReverseMap();
        }
    }
}
