using Newtonsoft.Json;
using System.Configuration;
using System.Text.Json.Nodes;
using MH.Application.IService.External;
using MH.Application.Response;
using MH.Domain.External;
using MH.Domain.Settings;

namespace MH.Application.Service.External
{
    public class FaceBookAuthService : IExternalAuthService
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}"; 
        private const string UserInfoUrl = "https://graph.facebook.com/me?fields=first_name,last_name,email,picture&access_token={0}";

        private readonly FacebookAuthSetting _facebookAuthSetting;
        private readonly IHttpClientFactory _httpClientFactory;

        public FaceBookAuthService(IHttpClientFactory httpClientFactory, FacebookAuthSetting facebookAuthSetting)
        {
            _httpClientFactory = httpClientFactory;
            _facebookAuthSetting = facebookAuthSetting;
        }

        public async  Task<T> GetUserInfoResult<T>(string accessToken)
        {
            var url = string.Format(UserInfoUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(url);
            result.EnsureSuccessStatusCode();
            var res = await result.Content.ReadAsStringAsync();
            //FacebookAuthResponse
            return JsonConvert.DeserializeObject<T>(res);
        }

        public async Task<T> ValidateAccessToken<T>(string accessToken)
        {
            var url = string.Format(TokenValidationUrl, accessToken, _facebookAuthSetting.AppId, _facebookAuthSetting.AppSecret);

            var result = await _httpClientFactory.CreateClient().GetAsync(url);
            var res = await result.Content.ReadAsStringAsync();
            if(!result.EnsureSuccessStatusCode().IsSuccessStatusCode)
            {
                //*TODO: Should replce magic string 
                throw new System.Exception("Facebook token not valid");
            }
            return JsonConvert.DeserializeObject<T>(res);
        }
    }
}
