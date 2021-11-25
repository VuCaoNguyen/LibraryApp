using LibraryApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
            if (username.Text == null)
            {
                DisplayAlert("Thông báo", "Nhập username", "OK");
                username.Focus();
            }
            else if (password.Text == null)
            {
                DisplayAlert("Thông báo", "Nhập password", "OK");
                password.Focus();
            }
            else
            {
                DataBase db = new DataBase();
                if (db.CheckUser(username.Text, password.Text))
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