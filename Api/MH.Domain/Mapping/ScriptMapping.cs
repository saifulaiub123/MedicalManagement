using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;

namespace MH.Domain.Mapping
{
    public class ScriptMapping : Profile
    {
        public ScriptMapping()
        {
            CreateMap<Script,ScriptModel>().ReverseMap();
            CreateMap<Script,ScriptViewModel>()
                .ForMember(a => a.DestinationServerName, b => b.MapFrom(b => b.Server.Name))
                .ForMember(a => a.UserName, b => b.MapFrom(b => b.CreatedByUser.Email));

            CreateMap<ScriptUserPermission, ScriptUserPermissionModel>().ReverseMap();
            CreateMap<ScriptUserPermission, SharedScriptUserViewModel>()
                .ForMember(a => a.Name, b => b.MapFrom(b => b.User.FullName))
                .ForMember(a => a.Email, b => b.MapFrom(b => b.User.Email));
        }
    }
}