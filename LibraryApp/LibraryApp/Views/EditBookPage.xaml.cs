using LibraryApp.Models;
using LibraryApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace LibraryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBookPage : ContentPage
    {
        Book thisBook;
        public EditBookPage()
        {
            InitializeComponent();
        }

        public EditBookPage(Book book)
        {
            InitializeComponent();
            InitialzingBook(book);
            this.thisBook = book;
        }

        void InitialzingBook(Book book)
        {
            bookTitle.Text = book.title;
            bookPrice.Text = book.price.ToString();
            bookImg.Text = book.img;

        }
        private void editBookBtn_Clicked(object sender, EventArgs e)
        {
            Book newBook = new Book();
            newBook.title = bookTitle.Text;
            newBook.price = Int32.Parse(bookPrice.Text);
            newBook.img = bookImg.Text;
            newBook.bID = thisBook.bID;

            DataBase db = new DataBase();
            if (db.UpdateOnebook(newBook))
            {
                DisplayAlert("Thông Báo", "Cập nhật sách thành công", "OK");
                Navigation.PushAsync(new AdminHomePage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Cập nhật thất bại", "OK");
            }
        }
    }
}