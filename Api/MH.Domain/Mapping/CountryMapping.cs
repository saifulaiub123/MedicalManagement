using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;
//using BWE.Domain.DBModel;
//using BWE.Domain.Model;
//using BWE.Domain.ViewModel;

namespace MH.Domain.Mapping
{
    public class CountryMapping : Profile
    {
        public CountryMapping()
        {
            CreateMap<Country,CountryModel>().ReverseMap();
            CreateMap<Country,CountryViewModel>().ReverseMap();
        }
    }
}
