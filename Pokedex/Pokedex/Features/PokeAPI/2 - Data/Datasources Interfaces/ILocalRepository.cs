using System;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.DatasourcesInterfaces
{
    public interface ILocalRepository
    {
        void SavePokemon(Pokemon pokemon);

        Pokemon GetPokemon(long pokemonId);

        void SavePage(Page page);

        Page GetPage(string pageId);
    }
}
