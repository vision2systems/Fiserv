using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vision.Vault.Fiserv.Afnis.API;

namespace Vision.Vault.Fiserv.Tests
{
    [TestClass]
    public class APIAuthenticationTests
    {
        [TestMethod]
        public void CanWeGetAnAccessToken()
        {
            var _url = "https://tcbtest.oktapreview.com/oauth2/default/v1/token";
            var clientId = "0oa23nmnyu4wbmB3C0h8";
            var secret = "WhO-P_fFLK9CqFhdZJObXy-N0ShwgLTXekEDJdho4QZsPweF3EHWhSiKEcCGBbn6";

            var authProider = new OAuthAccessTokenProvider(_url, HttpMethod.Post, clientId, secret);

            var token = authProider.BearerToken;

            Assert.IsNotNull(token);    
        }
    }
}
