using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThEvent.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThEvent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventListPage : ContentPage
    {
        void PutEvenst(string titlePattern, List<String> tagsList, DateTime dateTime, bool isPastEventsEnabled)
        {
            eventStackLayout.Children.Clear();
            var eventList = App.Database.GetEventsAsync();
            eventList.Sort((lhs, rhs) =>
                lhs.Date.CompareTo(rhs.Date));
            if (!String.IsNullOrEmpty(titlePattern)) 
                eventList = eventList.Where(x => x.Title.Contains(titlePattern)).ToList();
            if (dateTime > new DateTime(0001, 1, 1))
                eventList = eventList.Where(x => x.Date.Month == dateTime.Month && x.Date.Day == dateTime.Day && x.Date.Year == dateTime.Year).ToList();
            else if (!isPastEventsEnabled)
                eventList = eventList.Where(x => x.Date >= DateTime.Now).ToList();
            if (tagsList != null && tagsList.Count != 0)
            {
                foreach (string tag in tagsList)
                {
                    eventList = eventList.Where(x => x.EventTags.Contains(x.EventTags.Find(xx => xx.Title == tag))).ToList();
                }
            }

            foreach (var ev in eventList)
            {
                Label HeadlineLabel = new Label
                {
                    Text = ev.Title,
                    FontSize = 30,
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
                    Margin = new Thickness(20, 2),
                    Opacity = 0.9
                };

                var Tap = new TapGestureRecognizer();
                Tap.Tapped += async (a, b) =>
                {
                    await Navigation.PushAsync(new EventPage(ev));
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

            if (App.UserId != App.ANONYM_ID)
            {
                User currentUser = App.Database.GetUser();
                if (currentUser.IsAdmin)
                    AddEventButton();
            }
            AddLogout();
            PutEvenst(null, null, new DateTime(0001, 1, 1), false);
        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            App.UserId = App.ANONYM_ID;
            Navigation.PopToRootAsync();
        }
        
        private void FilterButtonClicked(object sender, EventArgs e)
        {
            FilterPage filterPage = new FilterPage();
            filterPage.Disappearing += (sender_, e_) =>
            {
                PutEvenst(filterPage.titlePattern, filterPage.tags, filterPage.date, filterPage.isPastEventsEnabled);
            };
            Navigation.PushAsync(filterPage);
        }

        private void AddClicked(object sender, EventArgs e)
        {
            var newAddEventPage = new AddEventListPage();
            Navigation.PushAsync(newAddEventPage);
            newAddEventPage.Disappearing += (s, a) =>
            {
                eventStackLayout.Children.Clear();
                PutEvenst(null, null, new DateTime(0001, 1, 1), false);
            };
        }

        private void ClearFilter(object sender, EventArgs e)
        {
            PutEvenst(null, null, new DateTime(0001, 1, 1), false);
        }
    }
}