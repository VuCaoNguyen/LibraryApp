using LibraryApp.Models;
using LibraryApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace LibraryApp.Views

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }


        private void register_Clicked(object sender, EventArgs e)
        {
            if (firstname.Text == null)
            {
                DisplayAlert("Thông báo", "Nhập firstname", "OK");
                firstname.Focus();
            }
            else if (lastname.Text == null)
            {
                DisplayAlert("Thông báo", "Nhập lastname", "OK");
                lastname.Focus();
            }
            else if (username.Text == null)
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

                string name = firstname.Text.Trim() + " " + lastname.Text.Trim();
                string usename = username.Text;
                string pwd = password.Text;
                bool isAdmin;
                if (isAdminSwitch.IsToggled)
                {
                    isAdmin = true;
                }
                else
                {
                    isAdmin = false;
                }
                User user = new User { Name = name, UserName = usename, PassWord = pwd, Admin = isAdmin };
                DataBase db = new DataBase();
                if (db.AddNewUser(user))
                {
                    DisplayAlert("Thông báo", "Tạo tài khoản thành công", "OK");
                    Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    DisplayAlert("Thông Báo", "Tạo tài khoản thất bại", "OK");
                }



            }


        }
    }
}