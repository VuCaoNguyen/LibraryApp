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
    public partial class AddBookPage : ContentPage
    {
        public AddBookPage()
        {
            InitializeComponent();
        }

        private void addBookBtn_Clicked(object sender, EventArgs e)
        {
            Book newBook = new Book();
            newBook.title = bookTitle.Text;
            newBook.price = Int32.Parse(bookPrice.Text);
            newBook.img = bookImg.Text;

            DataBase db = new DataBase();
            if (db.AddBook(newBook))
            {
                DisplayAlert("Thông Báo", "Thêm Sách Thành Công", "OK");
                Navigation.PushAsync(new AdminHomePage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Thêm Sách Thất bại", "OK");
            }
        }
    }
}