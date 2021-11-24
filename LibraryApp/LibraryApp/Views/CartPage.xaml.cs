using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LibraryApp.Models;
using LibraryApp.Services;
namespace LibraryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        int total = 0;
        Cart thiscart;
        public CartPage()
        {
            InitializeComponent();
            CartInit();
            amount.Text = "Thành tiền: " + total.ToString();
        }
        void CartInit()
        {
            List<Book> books = new List<Book>();
            DataBase db = new DataBase();
            List<Cart> carts = db.GetCart();

            foreach (Cart cart in carts)
            {
                var bookId = cart.bId;
                List<Book> temp = db.GetOneBook(bookId);
                if (temp.Count > 0)
                {
                    books.Add(temp.ElementAt(0));
                    total += temp.ElementAt(0).price;
                }

            };
            lstCart.ItemsSource = books;
        }

        private  void  delete_Clicked(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            var item = (Xamarin.Forms.Button)sender;
            Cart cart = (from itm in db.GetCart()
                             where itm.bId.ToString() == item.CommandParameter.ToString()
                             select itm)
                  .FirstOrDefault<Cart>();
            db.DeleteOneCark(cart);
            CartInit();

        }
    }
}