using System;

using Xamarin.Forms;
using RandomListXamarin.ViewModels;
using SharpTrooper.Entities;

namespace SWXamarin.ViewModels
{
    public class PersonDetailViewModel : BaseViewModel
    {
        private People _person;
        public People Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }
    }
}

