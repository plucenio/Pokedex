using System;
using System.Linq;
using LiteDB;
using Pokedex.Core.Services;
using Pokedex.Features.PokeAPI.Data.DatasourcesInterfaces;
using Pokedex.Features.PokeAPI.Domain.Entities;

namespace Pokedex.Features.PokeAPI.Data.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private string _stringConnection;
        private LiteDatabase _db;
        private LiteCollection<Pokemon> _pokemons;
        private LiteCollection<Page> _pages;

        public LocalRepository()
        {
            _stringConnection = string.Format("filename={0};journal=false", Xamarin.Forms.DependencyService.Get<IFileService>().GetLocalFilePath("Pokedex.db"));

            _db = new LiteDatabase(_stringConnection);
            _pokemons = (LiteCollection<Pokemon>)_db.GetCollection<Pokemon>();
            _pages = (LiteCollection<Page>)_db.GetCollection<Page>();
        }

        public void SavePokemon(Pokemon pokemon)
        {
            _pokemons.Insert(pokemon);
        }

        public Pokemon GetPokemon(string pokemonName)
        {
            return _pokemons.Find(x => x.Name == pokemonName).FirstOrDefault();
        }

        public void SavePage(Page page)
        {
            _pages.Insert(page);
        }

        public Page GetPage(string pageId)
        {
            return _pages.FindById(pageId);
        }
    }
}
