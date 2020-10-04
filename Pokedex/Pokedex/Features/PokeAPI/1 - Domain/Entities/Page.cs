using System;
using System.Collections.Generic;

namespace Pokedex.Features.PokeAPI.Domain.Entities
{
    public class Page
    {
        public string Id { get; set; }

        public Uri Next { get; set; }

        public Uri Previous { get; set; }

        public ItemListPokemon[] Pokemons { get; set; }
    }
}
