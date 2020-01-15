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
        static Event currentEvent;
        public EventPage(Event _currentEvent)
        {
            currentEvent = _currentEvent;
            InitializeComponent();

            Appearing += (s, e) =>
            {
                if (App.UserId == App.ANONYM_ID)
                    return;

                var check = App.Database._database.Table<UserEvents>()
                    .Where(ue => ue.UserId == App.UserId && ue.EventId == currentEvent.Id).ToListAsync().Result;
                if (check.Count != 0 || currentEvent.Date < DateTime.Now)
                    Participate.IsVisible = false;
            };

            var footer = Footer.getFooter();
            PageStackLayout.Children.Add(footer);

            Title.Text = currentEvent.Title;
            Info.Text = currentEvent.Info;
            Image.Source = ImageSource.FromUri(new Uri(currentEvent.Image));
            Data.Text = "Data:  " + currentEvent.Date.ToString("dd/MM/yyyy HH:mm");
            Address.Text = "Address:  " + currentEvent.Address;
            Tags.Text = "Tags: ";
            foreach(Tag t in currentEvent.EventTags)
            {
                Tags.Text += t.Title + ", ";
            }
            Tags.Text = Tags.Text.Substring(0, Tags.Text.Length - 2);
        }

        private void ParticipateClicked(object sender, EventArgs e)
        {
            if (App.UserId == App.ANONYM_ID)
            {
                DisplayAlert("", "You are not sign in.\nIf you haven't account,\nplease, sign up", "Ok");
                return;
            }
            UserEvents newUE = new UserEvents()
            {
                EventId = currentEvent.Id,
                UserId = App.UserId
            };
            App.Database.SaveUserEventAsync(newUE);
            DisplayAlert("", "Вы успешно зарегестирировались", "Ок");
        }
    }
}