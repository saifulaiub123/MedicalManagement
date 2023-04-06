using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class ContactDetailsMapping : Profile
    {
        public ContactDetailsMapping()
        {
            CreateMap<ContactDetails,ContactDetailsModel>().ReverseMap();
            CreateMap<ContactDetails,ContactDetailsViewModel>().ReverseMap();
        }
    }
}
