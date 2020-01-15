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
            Time.Time = new TimeSpan(DateTime.Now.Hour + 10, DateTime.Now.Minute, 0);
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            //TODO check if valid values and no empty fields

            foreach (Label label in tagList.Children) {
                string tagTitle = label.Text;
            }

            Event newEv = new Event()
            {
                Title = Title.Text,
                Date = new DateTime(Data.Date.Year, Data.Date.Month, Data.Date.Day, Time.Time.Hours, Time.Time.Minutes, 0),
                Image = Image.Text,
                Info = Info.Text,
                Address = Address.Text,
                CreatorId = App.UserId
            };
            App.Database.SaveEventAsync(newEv);
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
            Label findLabel = new Label();
            findLabel.Text = tagInput.Text;
            if (String.IsNullOrEmpty(tagInput.Text) || tagList.Children.Contains(findLabel)) return;
            AddTag(tagInput.Text);
            List<Tag> tagListDB = App.Database.GetTagsAsync().Result;
            if (tagListDB.Find(t => t.Title == tagInput.Text) == null)
            {
                Tag tag = new Tag() { Title = tagInput.Text };
                App.Database.SaveTagAsync(tag);
            }
            tagInput.Text = "";
            UpdateTags();
        }

        private void AddTag(string text)
        {
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