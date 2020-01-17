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
            UpdateTags();
            Time.Time = new TimeSpan((DateTime.Now.Hour + 10) % 24, DateTime.Now.Minute, 0);
            Address.TextChanged += (sender_, e_) =>
            {
                Address.BackgroundColor = Color.Default;
                if (Title.BackgroundColor != Color.FromHex("#E49696")) confirmError.IsVisible = false;
            };

            Title.TextChanged += (sender_, e_) =>
            {
                Title.BackgroundColor = Color.Default;
                if (Address.BackgroundColor != Color.FromHex("#E49696")) confirmError.IsVisible = false;
            };
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            //TODO check if valid values and no empty fields

            if (String.IsNullOrEmpty(Title.Text))
            {
                confirmError.IsVisible = true;
                Title.BackgroundColor = Color.FromHex("#E49696");
            }

            if (String.IsNullOrEmpty(Address.Text))
            {
                Address.BackgroundColor = Color.FromHex("#E49696");
                confirmError.IsVisible = true;
            }

            if (confirmError.IsVisible) return;

            Event newEv = new Event()
            {
                Title = Title.Text,
                Date = new DateTime(Data.Date.Year, Data.Date.Month, Data.Date.Day, Time.Time.Hours, Time.Time.Minutes, 0),
                Image = String.IsNullOrEmpty(Image.Text) ? "https://sun9-32.userapi.com/c854228/v854228393/1d421d/wGR9jttlZ8c.jpg" : Image.Text,
                Info = Info.Text,
                Address = Address.Text,
                CreatorId = App.UserId
            };


            _ = App.Database._database.InsertAsync(newEv).Result;
            int evId = App.Database._database.Table<Event>().ToListAsync().Result.LastOrDefault().Id;
            foreach (Label label in tagList.Children)
            {
                string title = label.Text;

                Tag tag = App.Database._database.Table<Tag>()
                    .FirstAsync(t => t.Title == title).Result;
                App.Database.SaveEventTagAsync(new EventTags
                {
                    EventId = evId,
                    TagId = tag.Id
                });
            }
            Navigation.PopAsync();
        }
        private void ChooseTag(object sender, EventArgs e)
        {
            if (tagPicker.SelectedIndex == -1) return;
            AddTag(tagPicker.Items[tagPicker.SelectedIndex]);
            tagPicker.SelectedIndex = -1;
        }

        private void AddTag(object sender, EventArgs e)
        {
            string tagName = tagInput.Text;
            tagInput.Text = "";
            if (!AddTag(tagName)) return;
            List<Tag> tagListDB = App.Database.GetTagsAsync().Result;
            if (tagListDB.Find(t => t.Title == tagName) == null)
            {
                Tag tag = new Tag() { Title = tagName };
                App.Database.SaveTagAsync(tag);
            }
            UpdateTags();
        }

        private bool AddTag(string text)
        {
            if (String.IsNullOrEmpty(text)) return false;
            foreach (Label l in tagList.Children)
            {
                if (l.Text == text)
                {
                    return false;
                }
            }
            Label label = new Label();
            label.Text = text;
            label.BackgroundColor = Color.Gray;
            var tap = new TapGestureRecognizer();
            tap.Tapped += async (sender_, e_) =>
            {
                if (await DisplayAlert("Подтвердите удаление", "Вы действительно хотите удалить этот тег?", "Да", "Нет"))
                {
                    tagList.Children.Remove(label);
                }
            };
            label.GestureRecognizers.Add(tap);
            tagList.Children.Add(label);
            return true;
        }
        private void UpdateTags()
        {
            List<Tag> tagListDB = App.Database.GetTagsAsync().Result;
            tagPicker.Items.Clear();
            foreach (Tag tag in tagListDB)
            {
                tagPicker.Items.Add(tag.Title);
            }
        }
    }
}