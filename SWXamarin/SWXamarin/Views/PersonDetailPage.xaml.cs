using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SWXamarin.ViewModels;

namespace SWXamarin.Views
{
    public partial class PersonDetailPage : ContentPage
    {
        public PersonDetailPage(PersonDetailViewModel personDetailViewModel)
        {
            InitializeComponent();
            BindingContext = personDetailViewModel;
        }
    }
}
