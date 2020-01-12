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
                User newUser = new User
                {
                    FirstName = Name.Text,
                    SecondName = SecondName.Text,
                    Email = Email.Text,
                    Password = password.Text
                };
                CheckEmailPage checkEmail = new CheckEmailPage();

                checkEmail.Appearing += (sender_, e_) =>
                {
                    MailAddress from = new MailAddress("thevent2020@mail.ru", "ThEvent-no-reply");
                    MailAddress to = new MailAddress(newUser.Email);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Код авторизации";
                    m.Body = "<h2>Код авторизации: </h2><h1>" + checkEmail.verifyCode.ToString() + "</h1><h3>Никому ему не говорите!</h3>";
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
                        App.Database.SaveUserAsync(newUser);
                        App.IsAnonym = false;
                        Navigation.PopAsync();
                        Navigation.PushAsync(new EventPage());
                    }
                };
                Navigation.PushAsync(checkEmail);
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