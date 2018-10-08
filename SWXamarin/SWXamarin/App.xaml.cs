using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SWXamarin.Views;
using SWXamarin.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SWXamarin
{
    public partial class App : Application
    {
        private static Locator _locator;
        ///<summary>
        /// static app wide locator
        /// </summary>
        public static Locator Locator => _locator ?? (_locator = new Locator());

        public App()
        {
            InitializeComponent();

            MainPage = new PeopleListViewPage(Locator.PeopleViewModel);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
