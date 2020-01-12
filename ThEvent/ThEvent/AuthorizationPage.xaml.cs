using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThEvent.Models;
using ThEvent.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThEvent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();
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
                Navigation.PopAsync();
                Navigation.PushAsync(new EventPage());
            }
        }
    }
}