using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ThEvent.Models;

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
        private void RegistrateClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
        private void AuthorizationClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AuthorizationPage());
        }

        private void AnonymousClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new EventListPage());
        }
        private void Registrate(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
    }
}
