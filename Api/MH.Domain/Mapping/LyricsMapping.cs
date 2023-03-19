using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class LyricsMapping : Profile
    {
        public LyricsMapping()
        {
            CreateMap<Lyrics,LyricsModel>().ReverseMap();
            CreateMap<Lyrics,LyricsViewModel>().ReverseMap();
        }
    }
}
