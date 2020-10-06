using System;
using Newtonsoft.Json;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.Models
{
    public partial class PokemonTypesModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public PokemonTypeModel[] Results { get; set; }
    }

    public partial class PokemonTypeModel : PokemonType
    {
        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
