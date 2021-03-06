﻿using System.Threading.Tasks;
using Pokedex.Features.PokeAPI.Data.Models;

namespace Pokedex.Features.PokeAPI.Data.Datasources
{
    public interface IPokeAPIDatasource
    {
        Task<PokemonModel> GetPokemon(string pokemonName);

        Task<PageModel> GetPage(string pageId);

        Task<PokemonTypeModel[]> GetPokemonTypes();

        Task<ItemListPokemonModel[]> GetPokemonsByType(string type);
    }
}
