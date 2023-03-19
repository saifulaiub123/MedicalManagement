using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class StateMapping : Profile
    {
        public StateMapping()
        {
            CreateMap<State,StateModel>().ReverseMap();
            CreateMap<State,StateViewModel>().ReverseMap();
        }
    }
}
