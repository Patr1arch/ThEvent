using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThEvent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEditPage : ContentPage
    {
        public ProfileEditPage(Models.User user)
        {
            InitializeComponent();

            userEmail.Text = user.Email;
            userFirstName.Text = user.FirstName;
            userSecondName.Text = user.SecondName;
            userInfo.Text = user.Info;
            userSex.SelectedIndex = user.Sex == "male" ? 0 : 1;
        }
        
        private void SaveClicked(object sender, EventArgs e)
        {

        }
        private void CancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}