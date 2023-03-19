using MH.Domain.External;

namespace MH.Application.IService.External
{
    public interface IExternalAuthService
    {
        Task<T> ValidateAccessToken<T>(string accessToken);
        Task<T> GetUserInfoResult<T>(string accessToken);
    }
}
