using System;
using System.Collections.Generic;

namespace Pokedex.Features.PokeAPI.Domain.Entities
{
    public class PokemonsByType
    {
        public virtual long Id { get; set; }

        public virtual ItemListPokemon[] ItemListPokemons { get; set; }
    }
}
