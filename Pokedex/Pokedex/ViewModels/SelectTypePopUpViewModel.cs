using System;
using System.Collections.Generic;
using System.Windows.Input;
using Pokedex.Features.PokeAPI.Data.Models;
using Pokedex.Features.PokeAPI.Domain.Entities;
using Pokedex.Features.PokeAPI.Domain.Usecases;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Pokedex.ViewModels
{
    public class SelectTypePopUpViewModel : ViewModelBase
    {
        private IEnumerable<PokemonType> types;

        public IEnumerable<PokemonType> Types
        {
            get => types;
            set
            {
                types = value;
                RaisePropertyChanged("Types");
            }
        }

        private PokemonType type;

        public PokemonType Type
        {
            get => type;
            set => type = value;
        }

        public IPokedexUsecase _usecase { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand SelectedTypeCommand { get; set; }

        public SelectTypePopUpViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IPokedexUsecase usecase)
            : base(navigationService, pageDialogService)
        {
            _usecase = usecase;
            CloseCommand = new DelegateCommand(async () =>
            {
                await SafelyExecute(async () =>
                {
                    Xamarin.Forms.MessagingCenter.Send<object>(string.Empty, "SearchByTypes");
                    await NavigationService.GoBackAsync();
                });
            });

            SelectedTypeCommand = new DelegateCommand(async () =>
            {
                await SafelyExecute(async () =>
                {
                    Xamarin.Forms.MessagingCenter.Send<object>(Type.Name, "SearchByTypes");
                    await NavigationService.GoBackAsync();
                });
            });
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await SafelyExecute(async () =>
            {
                Types = await _usecase.GetPokemonTypes();

                base.OnNavigatedTo(parameters);
            });
        }
    }
}
