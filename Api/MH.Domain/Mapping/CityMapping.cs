using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class CityMapping : Profile
    {
        public CityMapping()
        {
            CreateMap<City,CityModel>().ReverseMap();
            CreateMap<City,CityViewModel>().ReverseMap();
        }
    }
}
