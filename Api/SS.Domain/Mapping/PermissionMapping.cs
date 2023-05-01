using AutoMapper;
using SS.Domain.DBModel;
using SS.Domain.ViewModel;

namespace SS.Domain.Mapping
{
    public class PermissionMapping : Profile
    {
        public PermissionMapping()
        {
            CreateMap<PermissionViewModel, Permission>()
                .ReverseMap();
        }
    }
}
