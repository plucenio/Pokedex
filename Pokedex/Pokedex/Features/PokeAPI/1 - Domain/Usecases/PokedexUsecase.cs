using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.DatasourcesInterfaces;
using Pokedex.Features.PokeAPI.Domain.Entities;
using Pokedex.Features.PokeAPI.Domain.RepositoriesInterfaces;

namespace Pokedex.Features.PokeAPI.Domain.Usecases
{
    public interface IPokedexUsecase
    {
        Task<Pokemon> GetPokemon(long pokemonId);

        Task<Page> GetPage(string pageId);
    }

    public class PokedexUsecase : IPokedexUsecase
    {
        private readonly IPokeAPIRepository _pokeAPIRepository;
        private readonly ILocalRepository _localRepository;

        public PokedexUsecase(IPokeAPIRepository pokeAPIRepository, ILocalRepository localRepository)
        {
            _pokeAPIRepository = pokeAPIRepository;
            _localRepository = localRepository;
        }

        public async Task<Pokemon> GetPokemon(long pokemonId)
        {
            var pokemon = _localRepository.GetPokemon(pokemonId);
            if (pokemon == null)
            {
                pokemon = await _pokeAPIRepository.GetPokemon(pokemonId);
                _localRepository.SavePokemon(pokemon);
            }
            return pokemon;
        }

        public async Task<Page> GetPage(string pageId)
        {
            var page = _localRepository.GetPage(pageId);
            if (page == null)
            {
                page = await _pokeAPIRepository.GetPage(pageId);
                _localRepository.SavePage(page);
            }
            return page;
        }
    }
}
