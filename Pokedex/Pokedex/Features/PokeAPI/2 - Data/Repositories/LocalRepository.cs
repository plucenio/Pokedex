using System;
using LiteDB;
using Pokedex.Core.Services;
using Pokedex.Features.PokeAPI.Data.DatasourcesInterfaces;
using Pokedex.Features.PokeAPI.Domain.Entities;
using Xamarin.Forms;

namespace Pokedex.Features.PokeAPI.Data.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private string _stringConnection;
        private LiteDatabase _db;
        private LiteCollection<Pokemon> _pokemons;

        public LocalRepository()
        {
            _stringConnection = string.Format("filename={0};journal=false", DependencyService.Get<IFileService>().GetLocalFilePath("Pokedex.db"));

            _db = new LiteDatabase(_stringConnection);
            _pokemons = (LiteCollection<Pokemon>)_db.GetCollection<Pokemon>();
        }

        public void SavePokemon(Pokemon pokemon)
        {
            _pokemons.Insert(pokemon);
        }

        public Pokemon GetPokemon(long id)
        {
            return _pokemons.FindById(id);
        }

        public void SavePage(Domain.Entities.Page page)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Page GetPage(string pageId)
        {
            throw new NotImplementedException();
        }
    }
}
