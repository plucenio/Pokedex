using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.Models;
using Pokedex.Features.PokeAPI.Domain.Datasources;

namespace Pokedex.Features.PokeAPI.External.Datasources
{
    public class PokeAPIRepository : IPokeAPIRepository
    {
        private readonly IPokeAPIDatasource _pokeAPIDatasource;

        public PokeAPIRepository(IPokeAPIDatasource pokeAPIDatasource)
        {
            _pokeAPIDatasource = pokeAPIDatasource;
        }

        public async Task<PokemonModel> GetPokemon()
        {
            return await _pokeAPIDatasource.GetPokemon();
        }
    }
}
