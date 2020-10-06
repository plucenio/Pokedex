using Pokedex.Features.PokeAPI.Domain.Entities;
using Pokedex.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace Pokedex.Views
{
    public partial class SelectTypePopUp : PopupPage
    {
        public SelectTypePopUp()
        {
            InitializeComponent();
        }

        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ((SelectTypePopUpViewModel)this.BindingContext).SelectedTypeCommand.Execute(null);
        }
    }
}
