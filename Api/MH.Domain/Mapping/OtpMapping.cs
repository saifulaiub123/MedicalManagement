using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.ViewModel;

namespace MH.Domain.Mapping
{
    public class OtpMapping : Profile
    {
        public OtpMapping()
        {
            CreateMap<OtpViewModel,Otp>()
                .ReverseMap();
        }
    }
}
