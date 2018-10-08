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
    }
}
