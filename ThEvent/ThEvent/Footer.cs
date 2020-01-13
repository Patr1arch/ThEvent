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

        private static ImageButton createImButtonForFooter(string source)
        {
            var imButton = new ImageButton
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = source,
                WidthRequest = 40,
                HeightRequest = 40,
                BackgroundColor = Color,
                Margin = new Thickness(0, 5)
            };

            return imButton;
        }
        public static StackLayout getFooter()
        {
            Color = Color.FromHex("#90be7f");

            var eventButton = createImButtonForFooter("events.ico");
            eventButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new EventPage());
            };

            var rulesButton = createImButtonForFooter("rules.ico");
            rulesButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RulesPage());
            };

            var contactsButton = createImButtonForFooter("contacts.ico");
            contactsButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new ContactsPage());
            };

            var profileButton = createImButtonForFooter("profile.ico");
            profileButton.Clicked += async (a, b) =>
            {
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
