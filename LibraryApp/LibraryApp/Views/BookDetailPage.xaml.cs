using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LibraryApp.Services;
using LibraryApp.Models;
using LibraryApp.Views;
namespace LibraryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetailPage : ContentPage
    {
        Book book;
        public BookDetailPage(Book book)
        {
            InitializeComponent();
            bookImg.Source = book.img;
            bookTitle.Text = book.title;
            this.book = book;
        }

        private void delBtn_Clicked(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            if (db.DeleteOnebook(book))
            {
                DisplayAlert("Thông Báo", "Xóa Sách Thành Công", "OK");
                Navigation.PushAsync(new AdminHomePage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Xóa Sách Thất bại", "OK");
            }
        }

        private void editBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditBookPage(book));
        }
    }
}