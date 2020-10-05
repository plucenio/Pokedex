using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.Models;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Domain.RepositoriesInterfaces
{
    public interface IPokeAPIRepository
    {
        Task<Pokemon> GetPokemon(string pokemonName);

        Task<Page> GetPage(string pageId);
    }
}
