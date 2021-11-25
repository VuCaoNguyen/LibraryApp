using LibraryApp.Services;
using LibraryApp.Views;
using Xamarin.Forms;
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
