using System.Threading.Tasks;
using Newtonsoft.Json;
using Pokedex.Core.Services;
using Pokedex.Features.PokeAPI.Data.Models;
using Pokedex.Features.PokeAPI.Domain.Datasources;

namespace Pokedex.Features.PokeAPI.External.Datasources
{
    public class PokeAPIDatasource : IPokeAPIDatasource
    {
        private readonly IHttpClientService _httpClientService;

        public PokeAPIDatasource(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<PokemonModel> GetPokemon()
        {
            var response = await _httpClientService.GetAsync("");
            var str = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PokemonModel>(str);
        }
    }
}
