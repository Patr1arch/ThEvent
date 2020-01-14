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
        void PutEvenst()
        {
            var eventList = App.Database.GetEventsAsync().Result;
            eventList.Sort((lhs, rhs) =>
                lhs.Date.CompareTo(rhs.Date));

            foreach (var ev in eventList)
            {
                Label HeadlineLabel = new Label
                {
                    Text = ev.Title,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.Black
                };
                Label dateLabel = new Label
                {
                    Text = "" + ev.Date.ToString("dd/MM/yyyy HH:mm"),
                    TextColor = Color.Gray,
                    VerticalOptions = LayoutOptions.EndAndExpand
                };
                StackLayout innerStackLayout = new StackLayout
                {
                    Margin = 20,
                    Children = { HeadlineLabel, dateLabel }
                };

                Image image = new Image
                {
                    Source = ImageSource.FromUri(new Uri(ev.Image)),
                    HeightRequest = 140,
                    WidthRequest = 140,
                    HorizontalOptions = LayoutOptions.EndAndExpand
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
        void AddEventButton()
        {
            ToolbarItem AddEvent = new ToolbarItem
            {
                Text = "+",
                IconImageSource = "addEvent.png",
                Order = ToolbarItemOrder.Primary
            };
            AddEvent.Clicked += (s, e) =>
            {
                AddClicked(s, e);
            };
            this.ToolbarItems.Add(AddEvent);
        }
        void AddLogout()
        {
            ToolbarItem Logout = new ToolbarItem
            {
                Text = "+",
                IconImageSource = "logout.png",
                Order = ToolbarItemOrder.Primary
            };
            Logout.Clicked += (s, e) =>
            {
                LogoutClicked(s, e);
            };
            this.ToolbarItems.Add(Logout);
        }
        public EventListPage()
        {
            InitializeComponent();
            var footer = Footer.getFooter();
            PageStackLayout.Children.Add(footer);
            if (App.UserId != -1)
                AddEventButton();
            AddLogout();

            PutEvenst();
        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void AddClicked(object sender, EventArgs e)
        {
            var newAddEventPage = new AddEventListPage();
            Navigation.PushAsync(newAddEventPage);
            newAddEventPage.Disappearing += (s, a) =>
            {
                eventStackLayout.Children.Clear();
                PutEvenst();
            };
        }
    }
}