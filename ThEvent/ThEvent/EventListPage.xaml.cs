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
    public partial class EventListPage : ContentPage
    {
        public EventListPage()
        {
            InitializeComponent();
            var footer = Footer.getFooter();
            PageStackLayout.Children.Add(footer);

            var eventList = App.Database.GetEventsAsync().Result;
            //foreach (var ev in eventList)
            for (int i = 0; i < 7; i++)
            {
                //var ev = eventList[i];
                
                Label HeadlineLabel = new Label
                {
                    Text = "Чтобы мышцы росли как на дрожах, нужно всего лишь капля простого ...", // ev.HeadLine
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.Black
                };
                Label dateLabel = new Label
                {
                    Text = "" + DateTime.Now.ToString("MM/dd H:mm"), // ev.Date
                    TextColor = Color.Gray,
                    VerticalOptions = LayoutOptions.EndAndExpand
                };
                StackLayout innerStackLayout = new StackLayout
                {
                    Margin = 20,
                    Children = {HeadlineLabel, dateLabel}
                };

                Image image = new Image
                {
                    // ev.ImageURL
                    Source = ImageSource.FromUri(new Uri("https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg")),
                    HeightRequest = 140,
                    WidthRequest = 140
                };

                StackLayout mainStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { innerStackLayout, image }
                };

                var frame = new Frame
                {
                    Padding = 0,
                    Content = mainStackLayout,
                    Margin = new Thickness(20, 0)
                };

                var Tap = new TapGestureRecognizer();
                Tap.Tapped += async (a, b) =>
                {
                    await Navigation.PushAsync(new EventPage(/*ev*/));
                };

                frame.GestureRecognizers.Add(Tap);

                eventStackLayout.Children.Add(frame);
            }

        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void AddClicked(object sender, EventArgs e)
        {
            if (App.UserId == -1)
                DisplayAlert("Уведомление", "Чтобы иметь возможность добавить мероприятие, войдите в аккаунт", "OK");
            else
                Navigation.PushAsync(new AddEventListPage());
        }
    }
}