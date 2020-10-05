using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.Datasources;
using Pokedex.Features.PokeAPI.Domain.Entities;
using Pokedex.Features.PokeAPI.Domain.RepositoriesInterfaces;

namespace Pokedex.Features.PokeAPI.Data.Repositories
{
    public class PokeAPIRepository : IPokeAPIRepository
    {
        private readonly IPokeAPIDatasource _pokeAPIDatasource;

        public PokeAPIRepository(IPokeAPIDatasource pokeAPIDatasource)
        {
            _pokeAPIDatasource = pokeAPIDatasource;
        }

        public async Task<Page> GetPage(string pageId)
        {
            var model = await _pokeAPIDatasource.GetPage(pageId);
            return model.ToEntity(pageId);
        }

        public async Task<Pokemon> GetPokemon(string pokemonName)
        {
            var model = await _pokeAPIDatasource.GetPokemon(pokemonName);
            return model.ToEntity();
        }
    }
}
