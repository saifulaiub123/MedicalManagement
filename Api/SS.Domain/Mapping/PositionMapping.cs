using AutoMapper;
using SS.Domain.DBModel;
using SS.Domain.Model;
using SS.Domain.ViewModel;


namespace SS.Domain.Mapping
{
    public class PositionMapping : Profile
    {
        public PositionMapping()
        {
            CreateMap<Position,PositionModel>().ReverseMap();
            CreateMap<Position,PositionViewModel>().ReverseMap();
        }
    }
}
