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
    public partial class AddEventListPage : ContentPage
    {
        public AddEventListPage()
        {
            InitializeComponent();
            var footer = Footer.getFooter();
            PageStackLayout.Children.Add(footer);

            Data.MinimumDate = DateTime.Now;
            Data.MaximumDate = new DateTime(2100, 1, 1);
            Time.Format = "HH:mm";
            Time.Time = new TimeSpan(DateTime.Now.Hour + 10, DateTime.Now.Minute, 0);
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            //TODO check if valid values and no empty fields


            Event newEv = new Event()
            {
                Title = Title.Text,
                Date = new DateTime(Data.Date.Year, Data.Date.Month, Data.Date.Day, Time.Time.Hours, Time.Time.Minutes, 0),
                Image = Image.Text,
                Info = Info.Text
            };
            App.Database.SaveEventAsync(newEv);
            Navigation.PopAsync();
        }
    }
}