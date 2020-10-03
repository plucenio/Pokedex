using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Pokedex.Core.Services;
using Pokedex.Features.PokeAPI.External.Datasources;
using Pokedex.Features.PokeAPI.Data.Datasources;
using Pokedex.Features.PokeAPI.Domain.RepositoriesInterfaces;
using Pokedex.Features.PokeAPI.Domain.Usecases;
using Pokedex.Features.PokeAPI.Data.Repositories;
using Pokedex.Features.PokeAPI.Data.DatasourcesInterfaces;
using Pokedex.Views;
using Pokedex.ViewModels;

namespace Pokedex
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IHttpClientService, HttpClientService>();
            containerRegistry.RegisterSingleton<IPokeAPIDatasource, PokeAPIDatasource>();
            containerRegistry.RegisterSingleton<IPokeAPIRepository, PokeAPIRepository>();
            containerRegistry.RegisterSingleton<IPokedexUsecase, PokedexUsecase>();
            containerRegistry.RegisterSingleton<ILocalRepository, LocalRepository>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
