using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserProfile,UserProfileModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileViewModel>()
                .ForMember(a => a.CountryName, b => b.MapFrom(b => b.Country.Name))
                .ForMember(a => a.StateName, b => b.MapFrom(b => b.State.Name))
                .ForMember(a => a.CityName, b => b.MapFrom(b => b.City.Name))
                .ForMember(a => a.ProfileImage, b => b.MapFrom(b => System.Convert.ToBase64String(b.User.UserProfileImage.Data)))
                .ReverseMap();
        }
    }
}
