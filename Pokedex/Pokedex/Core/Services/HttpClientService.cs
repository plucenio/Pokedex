using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Pokedex.Core.Utils.Constants;

namespace Pokedex.Core.Services
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string param);
    }

    public class HttpClientService : IHttpClientService
    {
        public async Task<HttpResponseMessage> GetAsync(string param)
        {
            using (var client = ConfigureClient())
            {
                return await client.GetAsync(param);
            }
        }

        private HttpClient ConfigureClient()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Constants.URL_API),
                Timeout = TimeSpan.FromSeconds(100)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
