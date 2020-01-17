using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThEvent.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThEvent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEditPage : ContentPage
    {
        User user;
        public ProfileEditPage(User _user)
        {
            InitializeComponent();

            user = _user;
            userEmail.Text = user.Email;
            userFirstName.Text = user.FirstName;
            userSecondName.Text = user.SecondName;
            userInfo.Text = user.Info;
            userSex.SelectedIndex = user.Sex == "male" ? 0 : 1;
            userAge.Text = user.Age.ToString();
            userImage.Text = user.Image;

            userFirstName.TextChanged += (sender_, e_) =>
            {
                userFirstName.BackgroundColor = Color.Default;
                nameReject.IsVisible = false;
            };
        }
        
        private void SaveClicked(object sender, EventArgs e)
        {
            // TODO check if empty fields exist

            if (String.IsNullOrEmpty(userFirstName.Text))
            {
                nameReject.IsVisible = true;
                userFirstName.BackgroundColor = Color.FromHex("#E49696");
                return;
            }

            _ = App.Database._database.UpdateAsync(new User
            {
                Id = user.Id,
                FirstName = userFirstName.Text,
                SecondName = userSecondName.Text,
                Info = userInfo.Text,
                Sex = userSex.SelectedIndex == 0 ? "male" : "female",
                Age = String.IsNullOrEmpty(userAge.Text) ? (int?)null : int.Parse(userAge.Text),
                Password = user.Password,
                Image = String.IsNullOrEmpty(userImage.Text) ? "https://i.ya-webdesign.com/images/vector-avatars-default.png" : userImage.Text,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                UserEvents = user.UserEvents
            });
            Navigation.PopAsync();
        }
        private void CancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}