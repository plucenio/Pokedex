using System.Net.Http;
using System.Threading.Tasks;
using FakeItEasy;
using Moq;
using Pokedex.Core.Services;
using Pokedex.Features.PokeAPI.External.Datasources;
using PokedexTest.Features.PokeAPI.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xunit;

namespace PokedexTest
{
    public class PokeAPIDatasourceTest
    {
        public PokeAPIDatasourceTest()
        {
            var platformServicesFake = A.Fake<IPlatformServices>();
            Device.PlatformServices = platformServicesFake;
        }

        [Fact]
        public async void GetPokemonSuccess()
        {
            var myMoq = new Mock<IHttpClientService>();
            myMoq.Setup(x => x.GetAsync("")).Returns(() =>
            Task.FromResult(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(FileHelper.GetFileContents("Pokemon31.json")),
            }));

            var datasource = new PokeAPIDatasource(myMoq.Object);

            var pokemon = await datasource.GetPokemon();

            Assert.NotNull(pokemon);

            Assert.Equal(31, pokemon.Id);
        }

        [Fact]
        public async void GetPokemonEmpty()
        {
            var myMoq = new Mock<IHttpClientService>();
            myMoq.Setup(x => x.GetAsync("")).Returns(() =>
            Task.FromResult(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(FileHelper.GetFileContents("Empty.json")),
            }));

            var datasource = new PokeAPIDatasource(myMoq.Object);

            var pokemon = await datasource.GetPokemon();

            Assert.NotNull(pokemon);

            Assert.Equal(0, pokemon.Id);
        }

        [Fact]
        public async void GetPokemonFail()
        {
            var myMoq = new Mock<IHttpClientService>();
            myMoq.Setup(x => x.GetAsync("")).Returns(() =>
            Task.FromResult(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(FileHelper.GetFileContents("")),
            }));

            var datasource = new PokeAPIDatasource(myMoq.Object);

            var pokemon = await datasource.GetPokemon();

            Assert.Null(pokemon);
        }

        [Fact]
        public async void GetPokemonWrongFile()
        {
            var myMoq = new Mock<IHttpClientService>();
            myMoq.Setup(x => x.GetAsync("")).Returns(() =>
            Task.FromResult(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(FileHelper.GetFileContents("PokemonPage.json")),
            }));

            var datasource = new PokeAPIDatasource(myMoq.Object);

            var pokemon = await datasource.GetPokemon();

            Assert.NotNull(pokemon);

            Assert.Equal(0, pokemon.Id);
        }
    }
}
