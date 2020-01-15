using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace ThEvent
{
    class Footer
    {
        private static Xamarin.Forms.ImageButton createImButtonForFooter(string source)
        {
            var imButton = new Xamarin.Forms.ImageButton
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = source,
                WidthRequest = 40,
                HeightRequest = 40,
                BackgroundColor = Color.White
            };

            return imButton;
        }
        public static Frame getFooter()
        {

            var eventButton = createImButtonForFooter("events.ico");
            eventButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new EventListPage());
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
                if (App.UserId == App.ANONYM_ID)
                {
                    await App.Current.MainPage.DisplayAlert("Уведомление", "Чтобы просмотреть профиль, необходимо авторизоваться", "OK");
                    return;
                }
                await App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
            };

            var footerStackLayout = new StackLayout
            {
                Children =
                {
                    eventButton, rulesButton, contactsButton, profileButton
                },
                Orientation = StackOrientation.Horizontal
            };

            var frame = new Frame
            {
                HasShadow = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Content = footerStackLayout,
                Padding = 10,
                Opacity = 0.8
            };

            return frame;
        }

        private static void EventButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
