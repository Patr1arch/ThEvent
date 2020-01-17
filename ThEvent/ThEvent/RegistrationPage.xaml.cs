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
using System.Net;
using System.Net.Mail;

namespace ThEvent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            Name.TextChanged += (sender_, e_) =>
            {
                Name.BackgroundColor = Color.Default;
                Incorrect.IsVisible = false;
            };

            SecondName.TextChanged += (sender_, e_) =>
            {
                SecondName.BackgroundColor = Color.Default;
                Incorrect.IsVisible = false;
            };

            Email.TextChanged += (sender_, e_) =>
            {
                Email.BackgroundColor = Color.Default;
                Incorrect.IsVisible = false;
            };

            Sex.SelectedIndexChanged += (sender_, e_) =>
            {
                Sex.BackgroundColor = Color.Default;
                Incorrect.IsVisible = false;
            };

        }

        private void Check_Password(object sender, EventArgs e)
        {
            if (password.Text == checkPassword.Text)
            {
                password.BackgroundColor = Color.FromHex("#88C788");
                checkPassword.BackgroundColor = Color.FromHex("#88C788");
                Incorrect.IsVisible = false;
            }
            else
            {
                password.BackgroundColor = Color.FromHex("#E49696");
                checkPassword.BackgroundColor = Color.FromHex("#E49696");
            }
        }

        private void AuthorizationClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new AuthorizationPage());
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            var check = App.Database._database.Table<User>()
                .Where(ev => ev.Email == Email.Text).ToListAsync().Result;
            if (check.Count != 0)
            {
                Email.BackgroundColor = Color.FromHex("#E49696");
                InvalidLogin.IsVisible = true;
                return;
            }


            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";

            if (!String.IsNullOrEmpty(Name.Text) &&
                !String.IsNullOrEmpty(SecondName.Text) &&
                !String.IsNullOrEmpty(Email.Text) &&
                Regex.Match(Email.Text, pattern, RegexOptions.IgnoreCase).Success &&
                Sex.SelectedIndex != -1 &&
                !String.IsNullOrEmpty(password.Text) &&
                String.Equals(password.Text, checkPassword.Text))

            {
                User newUser = new User
                {
                    FirstName = Name.Text,
                    SecondName = SecondName.Text,
                    Email = Email.Text,
                    Password = password.Text,
                    Image = "https://i.ya-webdesign.com/images/vector-avatars-default.png",
                    IsAdmin = false
                };
                if (Sex.SelectedIndex == 0)
                    newUser.Sex = "male";
                else
                    newUser.Sex = "female";

                CheckEmailPage checkEmail = new CheckEmailPage();
                checkEmail.Appearing += (sender_, e_) =>
                {
                    MailAddress from = new MailAddress("thevent2020@mail.ru", "ThEvent-no-reply");
                    MailAddress to = new MailAddress(newUser.Email);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Код авторизации";
                    m.Body = "<h2>Код авторизации: </h2><h1>" + checkEmail.verifyCode.ToString() + "</h1><h3>Никому его не говорите!</h3>";
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                    smtp.Credentials = new NetworkCredential("thevent2020@mail.ru", "S_fgnz4P%5");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                };

                checkEmail.Disappearing += (sender_, e_) =>
                {
                    if (checkEmail.isVerified)
                    {
                        _ = App.Database.SaveUserAsync(newUser).Result;
                        App.UserId = App.Database._database.Table<User>().ToListAsync().Result.LastOrDefault().Id;
                        Navigation.PopToRootAsync();
                        Navigation.PushAsync(new EventListPage());
                    }
                };
                Navigation.PushAsync(checkEmail);
            }
            else
            {
                Incorrect.IsVisible = true;
                InvalidLogin.IsVisible = true;
                if (String.IsNullOrEmpty(Name.Text)) Name.BackgroundColor = Color.FromHex("#E49696");
                if (String.IsNullOrEmpty(SecondName.Text)) SecondName.BackgroundColor = Color.FromHex("#E49696");
                if (Sex.SelectedIndex == -1) Sex.BackgroundColor = Color.FromHex("#E49696");
                if (String.IsNullOrEmpty(Email.Text)
                    || !Regex.Match(Email.Text, pattern, RegexOptions.IgnoreCase).Success) Email.BackgroundColor = Color.FromHex("#E49696");
                if (!String.Equals(password.Text, checkPassword.Text))
                {
                    password.BackgroundColor = Color.FromHex("#E49696");
                    checkPassword.BackgroundColor = Color.FromHex("#E49696");
                }
                if (String.IsNullOrEmpty(password.Text)) password.BackgroundColor = Color.FromHex("#E49696");
                if (String.IsNullOrEmpty(checkPassword.Text)) checkPassword.BackgroundColor = Color.FromHex("#E49696");
            }
            

            List<User> debug = App.Database.GetUsersAsync().Result;
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}