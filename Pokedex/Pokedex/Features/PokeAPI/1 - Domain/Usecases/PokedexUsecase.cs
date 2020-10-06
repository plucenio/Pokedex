using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.DatasourcesInterfaces;
using Pokedex.Features.PokeAPI.Domain.Entities;
using Pokedex.Features.PokeAPI.Domain.RepositoriesInterfaces;

namespace Pokedex.Features.PokeAPI.Domain.Usecases
{
    public interface IPokedexUsecase
    {
        Task<Pokemon> GetPokemon(string pokemonName);

        Task<Page> GetPage(string pageId);

        Task<PokemonType[]> GetPokemonTypes();

        Task<ItemListPokemon[]> GetPokemonsByType(string type);
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

        public async Task<Pokemon> GetPokemon(string prokemonName)
        {
            var pokemon = _localRepository.GetPokemon(prokemonName);
            if (pokemon == null)
            {
                pokemon = await _pokeAPIRepository.GetPokemon(prokemonName);
                _localRepository.SavePokemon(pokemon);
            }
            return pokemon;
        }

        public async Task<Page> GetPage(string pageId)
        {
            if (pageId == null)
                pageId = "?limit=5&offset=0";

            var page = _localRepository.GetPage(pageId);
            if (page == null)
            {
                page = await _pokeAPIRepository.GetPage(pageId);
                _localRepository.SavePage(page);
            }
            return page;
        }

        public async Task<PokemonType[]> GetPokemonTypes()
        {
            return await _pokeAPIRepository.GetPokemonTypes();
        }

        public async Task<ItemListPokemon[]> GetPokemonsByType(string type)
        {
            return await _pokeAPIRepository.GetPokemonsByType(type);
        }
    }
}
