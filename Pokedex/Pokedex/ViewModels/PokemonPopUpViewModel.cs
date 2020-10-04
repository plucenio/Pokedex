using System;
using Prism.Navigation;

namespace Pokedex.ViewModels
{
    public class PokemonPopUpViewModel : ViewModelBase
    {
        public PokemonPopUpViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}
