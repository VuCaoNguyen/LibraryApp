using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LibraryApp.Views;
using LibraryApp.Services;
namespace LibraryApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DataBase db = new DataBase();
            db.createDatabase();
            MainPage = new NavigationPage(new LoginPage());
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
