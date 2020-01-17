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
        }
        
        private void SaveClicked(object sender, EventArgs e)
        {
            // TODO check if empty fields exist

            _ = App.Database._database.UpdateAsync(new User
            {
                Id = user.Id,
                FirstName = userFirstName.Text,
                SecondName = userSecondName.Text,
                Info = userInfo.Text,
                Sex = userSex.SelectedIndex == 0 ? "male" : "female",
                Age = int.Parse(userAge.Text),
                Password = user.Password,
                Image = userImage.Text,
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