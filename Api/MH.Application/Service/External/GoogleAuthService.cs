using Google.Apis.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;
using MH.Application.IService.External;
using MH.Domain.External;
using MH.Domain.Settings;

namespace MH.Application.Service.External
{
    public class GoogleAuthService //: IExternalAuthService
    {
        private const string TokenValidationUrl = "https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={0}";
        private const string UserInfoUrl = "https://www.googleapis.com/oauth2/v3/userinfo?access_token={0}";

        private readonly GoogleAuthSetting _googleAuthSetting;
        private readonly IHttpClientFactory _httpClientFactory;

        public GoogleAuthService(IHttpClientFactory httpClientFactory, GoogleAuthSetting googleAuthSetting)
        {
            _httpClientFactory = httpClientFactory;
            _googleAuthSetting = googleAuthSetting;
        }

        public async Task<TokenValidationResult> ValidateAccessToken(string accessToken)
        {
            //GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(accessToken);


            var validationSettings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new string[] { _googleAuthSetting.ClientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(accessToken, validationSettings);


            var url = string.Format(TokenValidationUrl, accessToken, _googleAuthSetting.ClientId, _googleAuthSetting.ClientSecret);

            var result = await _httpClientFactory.CreateClient().GetAsync(url);
            var res = await result.Content.ReadAsStringAsync();
            if (!result.EnsureSuccessStatusCode().IsSuccessStatusCode)
            {
                //*TODO: Should replce magic string 
                throw new System.Exception("Facebook token not valid");
            }
            return JsonConvert.DeserializeObject<TokenValidationResult>(res);
        }

        public async Task<FacebookUserInfoResult> GetUserInfoResult(string accessToken)
        {
            var url = string.Format(UserInfoUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(url);
            result.EnsureSuccessStatusCode();
            var res = await result.Content.ReadAsStringAsync();
            //FacebookAuthResponse
            return JsonConvert.DeserializeObject<FacebookUserInfoResult>(res);
        }
    }
}
