using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.Models;

namespace Pokedex.Features.PokeAPI.Data.Datasources
{
    public interface IPokeAPIDatasource
    {
        Task<PokemonModel> GetPokemon(long pokemonId);

        Task<PageModel> GetPage(string pageId);
    }
}
