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
        public static StackLayout getFooter()
        {
            var eventButton = new Button { Text = "Меропр", 
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            eventButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new EventPage());
            };

            var rulesButton = new Button { Text = "Правила",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            rulesButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RulesPage());
            };

            var contactsButton = new Button { Text = "Контакты",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            contactsButton.Clicked += async (a, b) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new ContactsPage());
            };

            var profileButton = new Button { Text = "Профиль",
                HorizontalOptions = LayoutOptions.CenterAndExpand
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
                BackgroundColor = Color.Gray
            };

            return footerStackLayout;
        }

        private static void EventButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
