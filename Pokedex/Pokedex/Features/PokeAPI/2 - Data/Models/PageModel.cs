using System;
using Newtonsoft.Json;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.Models
{
    public partial class PageModel : Page
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public override Uri Next { get; set; }

        [JsonProperty("previous")]
        public override Uri Previous { get; set; }

        [JsonProperty("results")]
        public ItemListPokemonModel[] ItemListPokemonModels { get; set; }

        public Page ToEntity(string id)
        {
            var page = new Page()
            {
                Id = id,
                Next = this.Next,
                Previous = this.Previous,
                ItemListPokemon = ItemListPokemonModels
            };
            return page;
        }
    }
}
