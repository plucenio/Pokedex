using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Pokedex.Features.PokeAPI.Domain.Entities;
using Pokedex.Features.PokeAPI.Domain.Usecases;
using Prism.Commands;
using Prism.Navigation;

namespace Pokedex.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Page Page { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        private IEnumerable<ItemListPokemon> pokemons;

        public IEnumerable<ItemListPokemon> Pokemons
        {
            get => pokemons;
            set
            {
                pokemons = value;
                RaisePropertyChanged("Pokemons");
            }
        }

        private ItemListPokemon pokemon;

        public ItemListPokemon Pokemon
        {
            get => pokemon;
            set => pokemon = value;
        }

        public ICommand PreviousCommand { get; set; }

        public ICommand NextCommand { get; set; }

        public ICommand ShowPokemonCommand { get; set; }

        private IPokedexUsecase _usecase;

        public MainPageViewModel(INavigationService navigationService, IPokedexUsecase usecase)
            : base(navigationService)
        {
            Title = "Main Page";
            _usecase = usecase;
            PreviousCommand = new DelegateCommand(async () =>
            {
                if (string.IsNullOrEmpty(Previous))
                    return;

                var ret = await RefreshPage(Previous);
            },
                () => !String.IsNullOrEmpty(Previous)
            );

            NextCommand = new DelegateCommand(async () =>
            {
                if (string.IsNullOrEmpty(Next))
                    return;

                var ret = await RefreshPage(Next);
            },
                () => !String.IsNullOrEmpty(Next)
            );

            ShowPokemonCommand = new DelegateCommand(async () =>
            {
                var name = Pokemon.Name;
                await NavigationService.NavigateAsync("NavigationPage/PokemonPopUp",
                    new NavigationParameters()
                    {
                        { Core.Utils.Constants.Constants.pokemonParameter, name }
                    }
                );
            });
        }

        private async Task<bool> RefreshPage(string url)
        {
            Page = await _usecase.GetPage(url);
            Next = Page.Next?.Query;
            Previous = Page.Previous?.Query;
            Pokemons = Page.Pokemons;
            ((DelegateCommand)PreviousCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)NextCommand).RaiseCanExecuteChanged();
            return Page != null;
        }

        public Xamarin.Forms.ImageSource UriToByteArrayConverter(string uri)
        {
            return Xamarin.Forms.ImageSource.FromUri(new Uri(uri));
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (Page == null)
            {
                _ = await RefreshPage(null);
            }

            NextCommand.CanExecute(null);
            base.OnNavigatedTo(parameters);
        }
    }
}
