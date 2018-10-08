﻿using System;
using GalaSoft.MvvmLight.Ioc;
using SWXamarin.ViewModels;
using MvvmLight.XamarinForms;
using SWXamarin.Views;
namespace SWXamarin.Helpers
{
    public class Locator
    {
        public const string PeopleListViewPage = "PeopleListViewPage";

        static Locator()
        {
            //register the viewmdoels
            SimpleIoc.Default.Register<PeopleViewModel>();

            //Create the navigation service
            var navigation = new NavigationService();
            //Configure the pages managed by the navigation service. Each page is referenced by a key.
            navigation.Configure(PeopleListViewPage, typeof(PeopleListViewPage));
            SimpleIoc.Default.Register(() => navigation);
        }

        public PeopleViewModel PeopleViewModel => SimpleIoc.Default.GetInstance<PeopleViewModel>();
        public NavigationService NavigationService => SimpleIoc.Default.GetInstance<NavigationService>();
    }
}