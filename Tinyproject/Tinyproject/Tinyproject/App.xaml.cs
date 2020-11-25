using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tinyproject.Views;

namespace Tinyproject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Top10Page());            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
