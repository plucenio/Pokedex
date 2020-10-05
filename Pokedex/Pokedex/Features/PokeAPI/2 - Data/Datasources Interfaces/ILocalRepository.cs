using System;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.DatasourcesInterfaces
{
    public interface ILocalRepository
    {
        void SavePokemon(Pokemon pokemon);

        Pokemon GetPokemon(string pokemonName);

        void SavePage(Page page);

        Page GetPage(string pageId);
    }
}
