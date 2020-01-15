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
            //ProfileImage.Source = ImageSource.FromUri(new Uri("https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg"));
            FullNameLabel.Text = user.FirstName + " " + user.SecondName;
            LoginLabel.Text = user.Email;
            AgeLabel.Text = Convert.ToString(user.Age);
            SexLabel.Text = user.Sex == "female" ? "Женский" : "Мужской";
            InfoLabel.Text = user.Info;

            var eventList = new List<Models.Event>(); // Получаем из юзера 
            int i = 0;
            foreach (var ev in eventList)
            {
                var image = new Image
                {
                    Source = new Uri(ev.Image),
                    WidthRequest = 100,
                    HeightRequest = 100
                };
                var shortDescLabel = new Label
                {
                    TextColor = Color.Black,
                    Text = ev.Title
                };
                var dateLabel = new Label
                {
                    Text = ev.Date.ToString("dd/MM/yyyy HH:mm")
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