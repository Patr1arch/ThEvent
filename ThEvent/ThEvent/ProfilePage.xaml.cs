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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            var footer = Footer.getFooter();
            PageStackLayout.Children.Add(footer);

            var user = App.Database.GetUsersAsync().Result.Find(u => u.Id == App.UserId);
            ProfileImage.Source = new Uri(user.Image);
            FullNameLabel.Text = user.FirstName + " " + user.SecondName;
            LoginLabel.Text = user.Email;
            AgeLabel.Text = Convert.ToString(user.Age);
            SexLabel.Text = user.Sex == "female" ? "Женский" : "Мужской";
            InfoLabel.Text = user.Info;

            var eventList = App.Database.GetUser().UserEvents;
            eventList.Sort((lhs, rhs) =>
                lhs.Date.CompareTo(rhs.Date));

            int i = 0, j = 0;
            foreach (var ev in eventList)
            {
                var image = new Image
                {
                    Source = new Uri(ev.Image)
                };
                var shortDescLabel = new Label
                {
                    TextColor = Color.Black,
                    Text = ev.Title,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                var dateLabel = new Label
                {
                    Text = ev.Date.ToString("dd/MM/yyyy HH:mm"),
                    Margin = new Thickness(10, 0, 0, 0)
                };

                var stackLayout = new StackLayout
                {
                    Children = { image, shortDescLabel, dateLabel }
                };

                var frame = new Frame
                {
                    Padding = 0,
                    Content = stackLayout
                };

                var Tap = new TapGestureRecognizer();
                Tap.Tapped += async (a, b) =>
                {
                    await Navigation.PushAsync(new EventPage(ev));
                };

                frame.GestureRecognizers.Add(Tap);

                if (i++ % 2 == 0)
                    leftStLt.Children.Add(frame);
                else
                    rightStLt.Children.Add(frame);
            }
        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            App.UserId = -1;
            Navigation.PopToRootAsync();
        }
    }
}