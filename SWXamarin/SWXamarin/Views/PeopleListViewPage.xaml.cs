﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SWXamarin.ViewModels;

namespace SWXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleListViewPage : ContentPage
    {
        public PeopleListViewPage()
        {
            InitializeComponent();

            BindingContext = new PeopleViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
        }
    }
}
