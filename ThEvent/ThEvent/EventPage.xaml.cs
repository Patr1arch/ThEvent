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
        public EventPage(/*Event myEvent*/)
        {
            InitializeComponent();
            var footer = Footer.getFooter();
            PageStackLayout.Children.Add(footer);

            FullDescriptionLabel.Text = "ASDKHGASJDGASGKJDGASDGASGDASGDGASHDASKHDKJHSAKJDHASKJHDKJHSADKJHASKHJDKJHAS";//myEvent.FullDescription;
            ShortDescriptionLabel.Text = "TemaTemaTemaTemaTemaTema"; //myEvent.ShortDescription;
            EventImage.Source = ImageSource.FromUri(new Uri("https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg"/*myEvent.ImageURL*/));
        }

        private void ParticipateClicked(object sender, EventArgs e)
        {

        }
    }
}