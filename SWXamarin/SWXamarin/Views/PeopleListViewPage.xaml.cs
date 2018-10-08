using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SWXamarin.ViewModels;
using SWXamarin.Helpers;
using SharpTrooper.Entities;

namespace SWXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleListViewPage : ContentPage
    {
        public PeopleListViewPage(PeopleViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as PeopleViewModel).ExecuteAddPageCommandAsync();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var personDetailViewModel = new PersonDetailViewModel();
            personDetailViewModel.Person = e.Item as People;
            App.Locator.NavigationService.NavigateTo(Locator.PersonDetailPageKey, personDetailViewModel);
        }
    }
}
