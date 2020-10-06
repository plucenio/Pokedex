using System;
using Newtonsoft.Json;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.Models
{
    public partial class ItemListPokemonModel : ItemListPokemon
    {
        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("url")]
        public override Uri Url { get; set; }
    }
}
