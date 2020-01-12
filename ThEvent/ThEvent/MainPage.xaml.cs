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
        /*protected override async void OnAppearing()
        {
            base.OnAppearing();
            var e = await App.Database.GetEventsAsync();
        }*/

        private void Registrate(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new RegistrationPage());
        }
    }
}
