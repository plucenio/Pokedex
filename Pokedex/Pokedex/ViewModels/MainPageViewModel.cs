﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Pokedex.Features.PokeAPI.Domain.Entities;
using Pokedex.Features.PokeAPI.Domain.Usecases;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Pokedex.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Page Page { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public string SelectedType { get; set; }

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

        public ICommand SearchByTypeCommand { get; set; }

        private IPokedexUsecase _usecase;

        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService, IPokedexUsecase usecase)
            : base(navigationService, pageDialogService)
        {
            Title = "Main Page";
            SelectedType = string.Empty;
            _usecase = usecase;
            PreviousCommand = new DelegateCommand(async () =>
            {
                await SafelyExecute(async () =>
                {
                    if (string.IsNullOrEmpty(Previous))
                        return;

                    if (!string.IsNullOrEmpty(SelectedType))
                    {
                        await pageDialogService.DisplayAlertAsync("Search restarted", "search restarted to display all pokemon types", "Ok");
                        SelectedType = string.Empty;
                    }

                    var ret = await RefreshPage(Previous);
                });
            },
                () => !String.IsNullOrEmpty(Previous)
            );

            NextCommand = new DelegateCommand(async () =>
            {
                await SafelyExecute(async () =>
                {
                    if (string.IsNullOrEmpty(Next))
                        return;

                    if (!string.IsNullOrEmpty(SelectedType))
                    {
                        await pageDialogService.DisplayAlertAsync("Search restarted", "search restarted to display all pokemon types", "Ok");
                        SelectedType = string.Empty;
                    }

                    var ret = await RefreshPage(Next);
                });
            },
                () => !String.IsNullOrEmpty(Next)
            );

            ShowPokemonCommand = new DelegateCommand(async () =>
            {
                await SafelyExecute(async () =>
                {
                    var name = Pokemon.Name;
                    await NavigationService.NavigateAsync("NavigationPage/PokemonPopUp",
                        new NavigationParameters()
                        {
                            { Core.Utils.Constants.Constants.pokemonParameter, name }
                        }
                    );
                });
            });

            SearchByTypeCommand = new DelegateCommand(async () =>
            {
                await SafelyExecute(async () =>
                {
                    await NavigationService.NavigateAsync("NavigationPage/SelectTypePopUp");
                });
            });

            Xamarin.Forms.MessagingCenter.Subscribe<object>(this, "SearchByTypes", async message =>
            {
                _ = await SafelyExecute(async () =>
                  {
                      SelectedType = message == null ? "" : (string)message;
                      if (string.IsNullOrEmpty((String)message))
                          _ = await RefreshPage(null);
                      else
                          Pokemons = await usecase.GetPokemonsByType((string)message);
                  });
            });
        }

        private async Task<bool> RefreshPage(string url)
        {
            return await SafelyExecute(async () =>
            {
                Page = await _usecase.GetPage(url);
                Next = Page.Next?.Query;
                Previous = Page.Previous?.Query;
                Pokemons = Page.ItemListPokemon;
                ((DelegateCommand)PreviousCommand).RaiseCanExecuteChanged();
                ((DelegateCommand)NextCommand).RaiseCanExecuteChanged();
                return Page != null;
            });
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await SafelyExecute(async () =>
            { 
                if (Page == null)
                    _ = await RefreshPage(null);

                NextCommand.CanExecute(null);
                base.OnNavigatedTo(parameters);
            });
        }
    }
}
