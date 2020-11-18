using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntecLoginPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage()
            {
                BackgroundColor = Color.White
            });
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
