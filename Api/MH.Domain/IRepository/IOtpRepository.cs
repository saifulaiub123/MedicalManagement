using MH.Domain.DBModel;

namespace MH.Domain.IRepository
{
    public interface IOtpRepository : IRepository<Otp, int>
    {
        Task<Otp> GetLatestOtp(string mobileNumber);
    }
}
