using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleAppIS4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClientHandler = new HttpClientHandler();
            // allow untrusted SSL certificates
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            // получаем метаданные openId нашего IS4
            var client = new HttpClient(httpClientHandler);

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // Flow 1
            var tokenClient = new TokenClient(client, new TokenClientOptions()
            {
                Address = disco.TokenEndpoint,
                ClientId = "m2m.client",
                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
            });
            var tokenResponse = await tokenClient.RequestPasswordTokenAsync("bob", "bob", "scope1");

            // Flow 2
            // запрашиваем токен (настраивается в Config.cs проекта IE4)
            //var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            //{
            //    Address = disco.TokenEndpoint,
            //    ClientId = "m2m.client",
            //    ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
            //    Scope = "scope1",

            //    UserName = "bob",
            //    Password = "bob"
            //});

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient(httpClientHandler);
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            Console.WriteLine("________________________________________________________________________");
            var responseWeather = await apiClient.GetAsync("https://localhost:6001/WeatherForecast");
            if (!responseWeather.IsSuccessStatusCode)
            {
                Console.WriteLine(responseWeather.StatusCode);
            }
            else
            {
                var content = await responseWeather.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
            Console.ReadLine();
        }
    }
}
