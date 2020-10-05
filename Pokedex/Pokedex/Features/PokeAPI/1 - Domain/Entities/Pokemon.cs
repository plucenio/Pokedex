using System;

namespace Pokedex.Features.PokeAPI.Domain.Entities
{
    public class Pokemon
    {
        public virtual long Id { get; set; }

        public virtual Uri Uri { get; set; }

        public virtual string Name { get; set; }

        public virtual string TypeString { get; set; }

        public virtual long Height { get; set; }

        public virtual long Weight { get; set; }

        public virtual string FrontDefault { get; set; }
    }
}
