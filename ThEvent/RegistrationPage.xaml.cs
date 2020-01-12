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
            else {
                password.BackgroundColor = Color.Red;
                password.BackgroundColor = Color.Red;
            }
        }
    }
}