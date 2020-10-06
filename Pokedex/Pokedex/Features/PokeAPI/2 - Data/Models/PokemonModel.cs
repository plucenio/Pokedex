using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.Models
{
    public partial class PokemonModel : Pokemon
    {
        [JsonProperty("forms")]
        public Species[] Forms { get; set; }

        [JsonProperty("height")]
        public override long Height { get; set; }

        [JsonProperty("id")]
        public override long Id { get; set; }

        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("types")]
        public TypeElement[] Types { get; set; }

        [JsonProperty("weight")]
        public override long Weight { get; set; }

        public Pokemon ToEntity()
        {
            return new Pokemon()
            {
                Id = this.Id,
                Name = this.Name,
                TypeString = this.Types[0].Type.Name,
                Height = this.Height,
                Weight = this.Weight,
                FrontDefault = this.Sprites.FrontDefault.AbsoluteUri
            };
        }
    }


    public partial class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Sprites
    {
        [JsonProperty("back_default")]
        public Uri BackDefault { get; set; }

        [JsonProperty("back_female")]
        public Uri BackFemale { get; set; }

        [JsonProperty("back_shiny")]
        public Uri BackShiny { get; set; }

        [JsonProperty("back_shiny_female")]
        public Uri BackShinyFemale { get; set; }

        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public Uri FrontFemale { get; set; }

        [JsonProperty("front_shiny")]
        public Uri FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public Uri FrontShinyFemale { get; set; }

        [JsonProperty("animated", NullValueHandling = NullValueHandling.Ignore)]
        public Sprites Animated { get; set; }
    }

    public partial class TypeElement
    {
        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("type")]
        public Species Type { get; set; }
    }
}
