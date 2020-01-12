using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ThEvent
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

<<<<<<< HEAD:ThEvent/ThEvent/ThEvent/MainPage.xaml.cs
        private void RegistrateClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }

        private void AnonymousClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new EventPage());
        }
=======
        private void Registrate(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
>>>>>>> d693f504906a9c38f7b1078b0d2b9bf920c39dec:ThEvent/ThEvent/MainPage.xaml.cs
    }
}
