using AutoMapper;
using SS.Domain.DBModel;
using SS.Domain.Model;
using SS.Domain.ViewModel;


namespace SS.Domain.Mapping
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserProfile,UserProfileModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileViewModel>().ReverseMap();
        }
    }
}
