using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Services;
using LibraryApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LibraryApp.Views;
namespace LibraryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminHomePage : ContentPage
    {
        public AdminHomePage()
        {
            InitializeComponent();
            ListViewInit();
        }
        void ListViewInit()
        {
            DataBase db = new DataBase();
            List<Book> books;

            books = db.GetAllBooks();
            avaiBooks.ItemsSource = books;
        }

        private void addBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddBookPage());
        }

        private void avaiBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book seletedBook = e.SelectedItem as Book;
            Navigation.PushAsync(new BookDetailPage(seletedBook));
        }
    }
}