using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.Models
{
    public partial class PokemonModel : Pokemon
    {
        [JsonProperty("abilities")]
        public Ability[] Abilities { get; set; }

        [JsonProperty("base_experience")]
        public long BaseExperience { get; set; }

        [JsonProperty("forms")]
        public Species[] Forms { get; set; }

        [JsonProperty("game_indices")]
        public GameIndex[] GameIndices { get; set; }

        [JsonProperty("height")]
        public override long Height { get; set; }

        [JsonProperty("held_items")]
        public HeldItem[] HeldItems { get; set; }

        [JsonProperty("id")]
        public override long Id { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("location_area_encounters")]
        public Uri LocationAreaEncounters { get; set; }

        [JsonProperty("moves")]
        public Move[] Moves { get; set; }

        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("stats")]
        public Stat[] Stats { get; set; }

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

    public partial class Ability
    {
        [JsonProperty("ability")]
        public Species AbilityAbility { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }
    }

    public partial class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class GameIndex
    {
        [JsonProperty("game_index")]
        public long GameIndexGameIndex { get; set; }

        [JsonProperty("version")]
        public Species Version { get; set; }
    }

    public partial class HeldItem
    {
        [JsonProperty("item")]
        public Species Item { get; set; }

        [JsonProperty("version_details")]
        public VersionDetail[] VersionDetails { get; set; }
    }

    public partial class VersionDetail
    {
        [JsonProperty("rarity")]
        public long Rarity { get; set; }

        [JsonProperty("version")]
        public Species Version { get; set; }
    }

    public partial class Move
    {
        [JsonProperty("move")]
        public Species MoveMove { get; set; }

        [JsonProperty("version_group_details")]
        public VersionGroupDetail[] VersionGroupDetails { get; set; }
    }

    public partial class VersionGroupDetail
    {
        [JsonProperty("level_learned_at")]
        public long LevelLearnedAt { get; set; }

        [JsonProperty("move_learn_method")]
        public Species MoveLearnMethod { get; set; }

        [JsonProperty("version_group")]
        public Species VersionGroup { get; set; }
    }

    public partial class GenerationV
    {
        [JsonProperty("black-white")]
        public Sprites BlackWhite { get; set; }
    }

    public partial class GenerationIv
    {
        [JsonProperty("diamond-pearl")]
        public Sprites DiamondPearl { get; set; }

        [JsonProperty("heartgold-soulsilver")]
        public Sprites HeartgoldSoulsilver { get; set; }

        [JsonProperty("platinum")]
        public Sprites Platinum { get; set; }
    }

    public partial class Versions
    {
        [JsonProperty("generation-i")]
        public GenerationI GenerationI { get; set; }

        [JsonProperty("generation-ii")]
        public GenerationIi GenerationIi { get; set; }

        [JsonProperty("generation-iii")]
        public GenerationIii GenerationIii { get; set; }

        [JsonProperty("generation-iv")]
        public GenerationIv GenerationIv { get; set; }

        [JsonProperty("generation-v")]
        public GenerationV GenerationV { get; set; }

        [JsonProperty("generation-vi")]
        public Dictionary<string, GenerationVi> GenerationVi { get; set; }

        [JsonProperty("generation-vii")]
        public GenerationVii GenerationVii { get; set; }

        [JsonProperty("generation-viii")]
        public GenerationViii GenerationViii { get; set; }
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

        [JsonProperty("other", NullValueHandling = NullValueHandling.Ignore)]
        public Other Other { get; set; }

        [JsonProperty("versions", NullValueHandling = NullValueHandling.Ignore)]
        public Versions Versions { get; set; }

        [JsonProperty("animated", NullValueHandling = NullValueHandling.Ignore)]
        public Sprites Animated { get; set; }
    }

    public partial class GenerationI
    {
        [JsonProperty("red-blue")]
        public RedBlue RedBlue { get; set; }

        [JsonProperty("yellow")]
        public RedBlue Yellow { get; set; }
    }

    public partial class RedBlue
    {
        [JsonProperty("back_default")]
        public Uri BackDefault { get; set; }

        [JsonProperty("back_gray")]
        public Uri BackGray { get; set; }

        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_gray")]
        public Uri FrontGray { get; set; }
    }

    public partial class GenerationIi
    {
        [JsonProperty("crystal")]
        public Crystal Crystal { get; set; }

        [JsonProperty("gold")]
        public Crystal Gold { get; set; }

        [JsonProperty("silver")]
        public Crystal Silver { get; set; }
    }

    public partial class Crystal
    {
        [JsonProperty("back_default")]
        public Uri BackDefault { get; set; }

        [JsonProperty("back_shiny")]
        public Uri BackShiny { get; set; }

        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_shiny")]
        public Uri FrontShiny { get; set; }
    }

    public partial class GenerationIii
    {
        [JsonProperty("emerald")]
        public Emerald Emerald { get; set; }

        [JsonProperty("firered-leafgreen")]
        public Crystal FireredLeafgreen { get; set; }

        [JsonProperty("ruby-sapphire")]
        public Crystal RubySapphire { get; set; }
    }

    public partial class Emerald
    {
        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_shiny")]
        public Uri FrontShiny { get; set; }
    }

    public partial class GenerationVi
    {
        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public Uri FrontFemale { get; set; }

        [JsonProperty("front_shiny")]
        public Uri FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public Uri FrontShinyFemale { get; set; }
    }

    public partial class GenerationVii
    {
        [JsonProperty("icons")]
        public DreamWorld Icons { get; set; }

        [JsonProperty("ultra-sun-ultra-moon")]
        public GenerationVi UltraSunUltraMoon { get; set; }
    }

    public partial class DreamWorld
    {
        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public object FrontFemale { get; set; }
    }

    public partial class GenerationViii
    {
        [JsonProperty("icons")]
        public DreamWorld Icons { get; set; }
    }

    public partial class Other
    {
        [JsonProperty("dream_world")]
        public DreamWorld DreamWorld { get; set; }

        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }

    public partial class OfficialArtwork
    {
        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }
    }

    public partial class Stat
    {
        [JsonProperty("base_stat")]
        public long BaseStat { get; set; }

        [JsonProperty("effort")]
        public long Effort { get; set; }

        [JsonProperty("stat")]
        public Species StatStat { get; set; }
    }

    public partial class TypeElement
    {
        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("type")]
        public Species Type { get; set; }
    }
}
