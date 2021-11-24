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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
           if(username.Text == null)
            {
                DisplayAlert("Thông báo", "Nhập username", "OK");
                username.Focus();
            } else if (password.Text == null)
            {
                DisplayAlert("Thông báo", "Nhập password", "OK");
                password.Focus();
            }
            else
            {
                DataBase db = new DataBase();
                if(db.CheckUser(username.Text, password.Text))
                {
                    DisplayAlert("Thông báo", "Đăng nhập thành công", "OK");

                    if (db.CheckRoleAdmin(username.Text, password.Text))
                    {
                        Navigation.PushAsync(new AdminHomePage());
                    }
                    else
                    {
                        Navigation.PushAsync(new UserHomePage());
                    }
                }
                else
                {
                    DisplayAlert("Thông báo", "Đăng nhập thất bại", "OK");

                }
            }
        }

    }
}