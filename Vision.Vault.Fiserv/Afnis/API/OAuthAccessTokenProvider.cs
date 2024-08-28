using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Flurl;
using Flurl.Http;

namespace Vision.Vault.Fiserv.Afnis.API
{
    public class OAuthAccessTokenProvider
    {
        private HttpMethod _httpMethod;
        private string _tokenGrantUrl;
        private string _accessToken;
        private string _clientId;
        private string _clientSecret;
        private DateTime _tokenExpiration;
        private static object _lock = new object(); 

        public OAuthAccessTokenProvider(string tokenGrantUrl, HttpMethod method, string clientId, string clientSecret) 
        { 
            _tokenGrantUrl = tokenGrantUrl;
            _httpMethod = method;
            _clientId = clientId;   
            _clientSecret = clientSecret;
        }

        public string BearerToken 
        { 
            get
            {
                if (IsTokenValid())
                    return _accessToken;

                return GetNewAccessToken();
            }
        }

        private bool IsTokenValid()
        {
            return (!String.IsNullOrEmpty(_accessToken) && DateTime.UtcNow.AddMinutes(2) < _tokenExpiration);
                

            
        }

        private string GetNewAccessToken()
        {
            lock(_lock)
            {
                if (_httpMethod == HttpMethod.Post)
                {
                    return GetNewTokenFromFormPost();
                }

                if (_httpMethod == HttpMethod.Get)
                {

                    //assumes query string
                    return GetNewTokenFromQueryStringGet();
                }

                throw new NotImplementedException("HttpMethod not implemented");
            }
           
        }

        private string GetNewTokenFromFormPost()
        {
            var authorization = $"{_clientId}:{_clientSecret}";
            var authBase64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(authorization));
            var url = $"{_tokenGrantUrl}";

            var grantRequest = url
                
                .WithBasicAuth(_clientId,_clientSecret)
                .WithHeader("Accept","application/json")
                .AllowAnyHttpStatus();

            var grantTask = grantRequest.PostUrlEncodedAsync(new
            {
                grant_type="client_credentials",
                scope="mulesoft"
            });
                

            grantTask.Wait();

            var response = grantTask.Result;
            if(response.StatusCode == 200)
            {
                var result = grantTask.Result.GetJsonAsync<TokenResponse>();
                result.Wait();

                var responseToken = result.Result;
                _accessToken = responseToken.access_token;
                _tokenExpiration = DateTime.UtcNow.AddSeconds(responseToken.expires_in);

                return _accessToken;
            }

            var errorTask = grantTask.Result.GetStringAsync();
            errorTask.Wait();

            throw new Exception($"Failed to get token from {_tokenGrantUrl} with status {response.StatusCode} and error {errorTask.Result}");
        }

        private string GetNewTokenFromQueryStringGet()
        {
            throw new NotImplementedException();
        }

        private class TokenResponse
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }

            public string scope { get; set; }

            public string refresh_token { get; set; }
        }
    }
}
