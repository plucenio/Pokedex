using System;
using Xamanimation;
using Xamarin.Forms;

namespace Pokedex.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (Resources["StoryBoardTranslation"] is StoryBoard storyBoardTranslation)
                await storyBoardTranslation.Begin();
            base.OnAppearing();
        }

        void ListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            ((ViewModels.MainPageViewModel)this.BindingContext).ShowPokemonCommand.Execute(null);
        }
    }
}
