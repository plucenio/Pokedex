using Pokedex.Features.PokeAPI.Domain.Usecases;
using Prism.Navigation;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ImageSource image;

        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                RaisePropertyChanged("Image");
            }
        }

        private IPokedexUsecase _usecase;

        public MainPageViewModel(INavigationService navigationService, IPokedexUsecase usecase)
            : base(navigationService)
        {
            Title = "Main Page";
            _usecase = usecase;
        }

        public ImageSource UriToByteArrayConverter(string uri)
        {
            return ImageSource.FromUri(new System.Uri(uri));
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            Image = UriToByteArrayConverter("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/12.png");

            //var pokemon = await _usecase.GetPokemon(11);

            base.OnNavigatedTo(parameters);
        }
    }
}
