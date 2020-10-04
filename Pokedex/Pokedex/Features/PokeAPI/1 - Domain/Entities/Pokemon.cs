using System;

namespace Pokedex.Features.PokeAPI.Domain.Entities
{
    public class Pokemon
    {
        public long Id { get; set; }

        public Uri Uri { get; set; }

        public string Name { get; set; }

        public string TypesString { get; set; }

        public long Height { get; set; }

        public long Weight { get; set; }

        public string FrontDefault { get; set; }
    }
}
