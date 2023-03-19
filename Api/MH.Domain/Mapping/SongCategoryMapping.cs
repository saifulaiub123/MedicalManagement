using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class SongCategoryMapping : Profile
    {
        public SongCategoryMapping()
        {
            CreateMap<SongCategory,SongCategoryModel>().ReverseMap();
            CreateMap<SongCategory,SongCategoryViewModel>().ReverseMap();
        }
    }
}
