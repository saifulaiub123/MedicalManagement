using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Domain.Mapping
{
    public class CollaboratorMapping : Profile
    {
        public CollaboratorMapping()
        {
            CreateMap<Collaborator,CollaboratorModel>().ReverseMap();
            CreateMap<Collaborator,CollaboratorViewModel>().ReverseMap();
        }
    }
}
