using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThEvent.Models;
using ThEvent.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ThEvent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();

            Email.TextChanged += (sender_, e_) =>
            {
                Email.BackgroundColor = Color.Default;
                Password.BackgroundColor = Color.Default;
                IncorrectSignIn.IsVisible = false;
            };

            Password.TextChanged += (sender_, e_) =>
            {
                Email.BackgroundColor = Color.Default;
                Password.BackgroundColor = Color.Default;
                IncorrectSignIn.IsVisible = false;
            };

            Appearing += (s, e) =>
            {
                string logPasFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "keepMe.json");
                if (File.Exists(logPasFile))
                {
                    KeepMe.IsChecked = true;
                    JObject logPas = JObject.Parse(File.ReadAllText(logPasFile));
                    Email.Text = logPas["email"].ToString();
                    Password.Text = logPas["password"].ToString();
                }
            };
        }

        private void RegistrateClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new RegistrationPage());
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            var deb = App.Database.GetUsersAsync().Result;

            var userTask = from u in App.Database._database.Table<User>()
                       where u.Password == Password.Text && u.Email == Email.Text
                       select u;
            List<User> user = userTask.ToListAsync().Result;

            if (user.Any())
            {
                if (KeepMe.IsChecked)
                {
                    string logPasFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "keepMe.json");
                    JObject logPas = new JObject(
                        new JProperty("email", Email.Text),
                        new JProperty("password", Password.Text)
                        );
                    File.WriteAllText(logPasFile, logPas.ToString());
                }
                else
                {
                    string logPasFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "keepMe.json");
                    if (File.Exists(logPasFile))
                    {
                        File.Delete(logPasFile);
                    }
                }

                App.IsAnonym = false;
                Navigation.PopAsync();
                Navigation.PushAsync(new EventPage());
            }
            else
            {
                IncorrectSignIn.IsVisible = true;
                Email.BackgroundColor = Color.Red;
                Password.BackgroundColor = Color.Red;
            }
        }
    }
}