using System;
namespace Pokedex.Features.PokeAPI.Domain.Entities
{
    public class ItemListPokemon
    {
        public virtual string Name { get; set; }

        public virtual Uri Url { get; set; }
    }
}
