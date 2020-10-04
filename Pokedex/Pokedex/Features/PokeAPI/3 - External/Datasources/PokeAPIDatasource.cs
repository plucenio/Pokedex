using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pokedex.Core.Services;
using Pokedex.Features.PokeAPI.Data.Datasources;
using Pokedex.Features.PokeAPI.Data.Models;

namespace Pokedex.Features.PokeAPI.External.Datasources
{
    public class PokeAPIDatasource : IPokeAPIDatasource
    {
        private readonly IHttpClientService _httpClientService;

        public PokeAPIDatasource(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<PageModel> GetPage(string pageId)
        {
            var response = await _httpClientService.GetAsync($"pokemon/{pageId}");
            var str = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PageModel>(str);
        }

        public async Task<PokemonModel> GetPokemon(long pokemonId)
        {
            var response = await _httpClientService.GetAsync($"pokemon/{pokemonId}");
            var str = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PokemonModel>(str);
        }
    }
}
