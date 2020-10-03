using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.Models;

namespace Pokedex.Features.PokeAPI.Domain.Datasources
{
    public interface IPokeAPIDatasource
    {
        Task<PokemonModel> GetPokemon();
    }
}
