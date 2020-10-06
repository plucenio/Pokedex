using System;
using Newtonsoft.Json;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.Models
{
    public class PokemonsByTypeModel : PokemonsByType
    {
        [JsonProperty("id")]
        public override long Id { get; set; }

        [JsonProperty("pokemon")]
        public PokemonItem[] ItemListPokemonModels { get; set; }
    }

    public class PokemonItem
    {
        [JsonProperty("pokemon")]
        public ItemListPokemonModel ItemListPokemonModel { get; set; }
    }
}
