using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThEvent
{
    class Footer
    {
        public static Color Color;
        public static StackLayout getFooter()
        {
            Color = Color.FromHex("#90be7f");

            var eventButton = new ImageButton {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = "events.ico",
                WidthRequest = 50,
                HeightRequest = 50,
                BackgroundColor = Color,
                Margin = new Thickness(0, 10)
            };
            eventButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new EventPage());
            };

            var rulesButton = new ImageButton {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = "rules.ico",
                WidthRequest = 50,
                HeightRequest = 50,
                BackgroundColor = Color,
                Margin = new Thickness(0, 20)
            };
            rulesButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RulesPage());
            };

            var contactsButton = new ImageButton {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = "contacts.ico",
                WidthRequest = 50,
                HeightRequest = 50,
                BackgroundColor = Color,
                Margin = new Thickness(0, 20)
            };
            contactsButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new ContactsPage());
            };

            var profileButton = new ImageButton {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = "profile.ico",
                WidthRequest = 50,
                HeightRequest = 50,
                BackgroundColor = Color,
                Margin = new Thickness(0, 20)
            };
            profileButton.Clicked += async (a, b) => {
                await App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
            };

            var footerStackLayout = new StackLayout
            {
                Children =
                {
                    eventButton, rulesButton, contactsButton, profileButton
                },
                VerticalOptions = LayoutOptions.EndAndExpand,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color
            };

            return footerStackLayout;
        }

        private static void EventButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
