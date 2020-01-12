using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThEvent.Models;
using ThEvent.Data;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace ThEvent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Check_Password(object sender, EventArgs e)
        {
            if (password.Text == checkPassword.Text)
            {
                password.BackgroundColor = Color.Green;
                checkPassword.BackgroundColor = Color.Green;
            }
            else
            {
                password.BackgroundColor = Color.Red;
                checkPassword.BackgroundColor = Color.Red;
            }
        }

        private void AuthorizationClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new AuthorizationPage());
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";       

            if (!String.IsNullOrEmpty(Name.Text) &&
                !String.IsNullOrEmpty(SecondName.Text) &&
                !String.IsNullOrEmpty(Email.Text) &&
                Regex.Match(Email.Text, pattern, RegexOptions.IgnoreCase).Success &&
                Sex.SelectedIndex != -1 &&
                !String.IsNullOrEmpty(password.Text) &&
                String.Equals(password.Text, checkPassword.Text))

            {
                App.Database.SaveUserAsync(
                    new User
                    {
                        FirstName = Name.Text,
                        SecondName = SecondName.Text,
                        Email = Email.Text,
                        Password = password.Text
                    });
                App.IsAnonym = false;
                Navigation.PopAsync();
                Navigation.PushAsync(new EventPage());
            }
            else
            {
                Incorrect.IsVisible = true;
                if (String.IsNullOrEmpty(Name.Text)) Name.BackgroundColor = Color.Red;
                if (String.IsNullOrEmpty(SecondName.Text)) SecondName.BackgroundColor = Color.Red;
                if (Sex.SelectedIndex == -1) Sex.BackgroundColor = Color.Red;
                if (String.IsNullOrEmpty(Email.Text)
                    || !Regex.Match(Email.Text, pattern, RegexOptions.IgnoreCase).Success) Email.BackgroundColor = Color.Red;
                if (!String.Equals(password.Text, checkPassword.Text))
                {
                    password.BackgroundColor = Color.Red;
                    checkPassword.BackgroundColor = Color.Red;
                }
                if (String.IsNullOrEmpty(password.Text)) password.BackgroundColor = Color.Red;
                if (String.IsNullOrEmpty(checkPassword.Text)) checkPassword.BackgroundColor = Color.Red;
            }
            

            List<User> debug = App.Database.GetUsersAsync().Result;
        }
    }
}