using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LibraryApp.Services;
using LibraryApp.Models;
namespace LibraryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserHomePage : ContentPage
    {
        public UserHomePage()
        {
            InitializeComponent();
            ListViewInit();
        }

        void ListViewInit()
        {
            DataBase db = new DataBase();
            List<Book> books = db.GetAllBooks();
            avaiBooks.ItemsSource = books;
        }
        private void avaiBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = (Book)avaiBooks.SelectedItem;
            Navigation.PushAsync(new AddToCartPage(selectedBook));
        }

        private void cartBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartPage());
        }
    }
}