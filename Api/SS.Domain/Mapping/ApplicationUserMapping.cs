using AutoMapper;
using SS.Domain.DBModel;
using SS.Domain.Model;
using SS.Domain.ViewModel;

namespace SS.Domain.Mapping
{
    public class ApplicationUserMapping : Profile
    {
        public ApplicationUserMapping()
        {
            CreateMap<RegisterModel,ApplicationUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u=>u.PasswordHash, opt=> opt.MapFrom(x=> x.Password))
                .ReverseMap();

            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();

            CreateMap<UserRole, UserRoleViewModel>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();
        }
    }
}
