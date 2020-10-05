using System;
using Pokedex.Features.PokeAPI.Domain.Entities;
using Pokedex.Features.PokeAPI.Domain.Usecases;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class PokemonPopUpViewModel : ViewModelBase
    {
        private IPageDialogService _pageDialogService { get; set; }

        public ImageSource ImgSource
        {
            get => imgSource;
            set
            {
                imgSource = value;
                RaisePropertyChanged("ImgSource");
            }
        }

        private Pokemon pokemon;
        private ImageSource imgSource;

        public Pokemon Pokemon
        {
            get => pokemon;
            set
            {
                pokemon = value;
                RaisePropertyChanged("Pokemon");
            }
        }

        public IPokedexUsecase _usecase { get; set; }

        public PokemonPopUpViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IPokedexUsecase usecase)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _usecase = usecase;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters.ContainsKey(Core.Utils.Constants.Constants.pokemonParameter))
                {
                    Pokemon = await _usecase.GetPokemon((string)parameters[Core.Utils.Constants.Constants.pokemonParameter]);
                    if (Pokemon.FrontDefault != null)
                        ImgSource = new Uri(Pokemon.FrontDefault);
                }
                base.OnNavigatedTo(parameters);
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");
            }
        }
    }
}
