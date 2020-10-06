using System;
namespace Pokedex.Features.PokeAPI.Domain.Entities
{
    public class ItemListPokemon
    {
        public virtual long Id
        {
            get
            {
                long.TryParse(Url.Segments.GetValue(4).ToString().Replace("/", ""), out var result);
                return result;
            }
        }

        public virtual string Name { get; set; }

        public virtual Uri Url { get; set; }

        public string Front_Default
        {
            get
            {
                return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{this.Id.ToString()}.png";
            }
        }
    }
}
