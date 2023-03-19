using MH.Application.Response;
using MH.Domain.Model;

namespace MH.Application.IService
{
    public interface IOtpService
    {
        Task SendOtp(string mobileNumber);
        Task<OtpResponse> VerifyOtp(VerifyOtp verifyOtp);
    }
}
