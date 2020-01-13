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
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();
            var footer = Footer.getFooter();
            PageStackLayout.Children.Add(footer);

            var eventList = App.Database.GetEventsAsync().Result;
            //foreach (var ev in eventList)
            for (int i = 0; i < 7; i++)
            {
                Frame frame = new Frame
                {
                    BorderColor = Color.Accent
                };

                Image image = new Image
                {
                    // ev.ImageURL
                    Source = ImageSource.FromUri(new Uri("https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg"))
                    , HeightRequest = 140
                };
                Label dateLabel = new Label
                {
                    Text = "" + DateTime.Now.ToString("MM/dd H:mm"), // ev.Date
                    TextColor = Color.Gray,
                    VerticalOptions = LayoutOptions.End,
                    HorizontalTextAlignment = TextAlignment.Start
                };
                Label descriptionLabel = new Label
                {
                    Text = "Тут краткое описание, шикардосик. Приходите, Дадим поесть" // ev.ShortDescription
                };

                StackLayout stackLayout = new StackLayout
                {
                    Children = {image, dateLabel, descriptionLabel}
                };
                frame.Content = stackLayout;
                if (i % 2 == 0)
                {
                    leftStLt.Children.Add(frame);
                }
                else
                {
                    rightStLt.Children.Add(frame);
                }
            }

        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}