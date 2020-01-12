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
                password.BackgroundColor = Color.Red;
            }
        }

        private void AuthorizationClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new AuthorizationPage());
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            // TODO check if all enties was filled
            
            App.Database.SaveUserAsync(
                new User
                {
                    FirstName = Name.Text,
                    SecondName = SecondName.Text,
                    Email = Email.Text
                });
            Navigation.PopAsync();
            Navigation.PushAsync(new EventPage());

            List<User> debug = App.Database.GetUsersAsync().Result;
        }
    }
}