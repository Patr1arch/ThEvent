using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ThEvent.Models;

namespace ThEvent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        public EventPage(Event currentEvent)
        {
            InitializeComponent();
            var footer = Footer.getFooter();
            PageStackLayout.Children.Add(footer);

            Title.Text = currentEvent.Title;
            Info.Text = currentEvent.Info;
            Image.Source = ImageSource.FromUri(new Uri(currentEvent.Image));
            Data.Text = "Data:  " + currentEvent.Date.ToString("dd/MM/yyyy HH:mm");
            Address.Text = "Address:  " + currentEvent.Address;
        }

        private void ParticipateClicked(object sender, EventArgs e)
        {
            //TODO add data in bd
        }
    }
}