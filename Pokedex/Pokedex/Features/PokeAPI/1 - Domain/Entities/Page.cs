using System;

namespace Pokedex.Features.PokeAPI.Domain.Entities
{
    public class Page
    {
        public virtual string Id { get; set; }

        public virtual Uri Next { get; set; }

        public virtual Uri Previous { get; set; }

        public virtual ItemListPokemon[] ItemListPokemon { get; set; }
    }
}
