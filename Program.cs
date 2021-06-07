using System;
using System.Threading.Tasks;
using  Microsoft.Identity.Client;
using Flurl.Http;

namespace msal
{
    class Program
    {
        static async Task Main(string[] args)
        {
           
            string clientId = "2a8e03cd-69c9-446c-842f-a734358b75e2";
            string _tenantId = "3f7a3df4-f85b-4ca8-98d0-08b1034e6567";

            var app = PublicClientApplicationBuilder.Create(clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                        .WithRedirectUri("http://localhost")
                        .Build();

            string[] scopes = new string []
            {
                "https://graph.microsoft.com/user.read"
            };        

            var result = await app.AcquireTokenInteractive(scopes)
                .ExecuteAsync();

            Console.Write(result.AccessToken);    

            string json = await "https://graph.microsoft.com/v1.0/me"
                .WithOAuthBearerToken(result.AccessToken)
                .GetStringAsync();

            
            Console.WriteLine(json);




        }
    }
}
