using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class SongMapping : Profile
    {
        public SongMapping()
        {
            CreateMap<Song,SongModel>().ReverseMap();
            CreateMap<Song,SongViewModel>().ReverseMap();
        }
    }
}
