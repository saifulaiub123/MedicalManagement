using AutoMapper;
using SS.Domain.DBModel;
using SS.Domain.Model;
using SS.Domain.ViewModel;


namespace SS.Domain.Mapping
{
    public class ContactDetailsMapping : Profile
    {
        public ContactDetailsMapping()
        {
            CreateMap<ContactDetails,ContactDetailsModel>()
                .ReverseMap()
                .ForSourceMember(x => x.Userid, y => y.DoNotValidate());
            CreateMap<ContactDetails,ContactDetailsViewModel>()
                .ForMember(u => u.UserId, dest => dest.MapFrom(x => x.UserProfile.UserId))
                .ForMember(u => u.ContactDataTypeName, dest => dest.MapFrom(x => x.ContactDataType.Name))
                .ForMember(u => u.ContactTypeName, dest => dest.MapFrom(x => x.ContactType.Name))
                .ForMember(u => u.ContactEntityName, dest => dest.MapFrom(x => x.ContactEntity.Name))
                .ReverseMap();
        }
    }
}
