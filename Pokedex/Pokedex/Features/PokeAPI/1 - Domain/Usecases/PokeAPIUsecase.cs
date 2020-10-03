using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.Models;
using Pokedex.Features.PokeAPI.Domain.Datasources;

namespace Pokedex.Features.PokeAPI.External.Datasources
{
    public interface IPokeAPIUsecase
    {
        Task<PokemonModel> GetPokemon();
    }

    public class PokeAPIUsecase : IPokeAPIUsecase
    {
        private readonly IPokeAPIRepository _pokeAPIRepository;

        public PokeAPIUsecase(IPokeAPIRepository pokeAPIRepository)
        {
            _pokeAPIRepository = pokeAPIRepository;
        }

        public async Task<PokemonModel> GetPokemon()
        {
            return await _pokeAPIRepository.GetPokemon();
        }
    }
}
