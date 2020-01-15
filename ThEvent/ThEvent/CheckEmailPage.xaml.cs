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
    public partial class CheckEmailPage : ContentPage
    {
        public bool isVerified;
        public int verifyCode;
        public CheckEmailPage()
        {
            isVerified = false;
            Random random = new Random((int)DateTime.Now.Ticks);
            verifyCode = random.Next(10000, 99999);         

            InitializeComponent();
        }

        private void CheckCode(object sender, EventArgs e)
        {
            if (String.Equals(entryCode.Text, verifyCode.ToString())) {
                isVerified = true;
                Navigation.PopAsync();
            }
            else
            {
                entryCode.BackgroundColor = Color.FromHex("#E49696");
                incorrectCode.IsVisible = true;
            }
        }

        private void EntryCodeTextChanged(object sender, TextChangedEventArgs e)
        {
            entryCode.BackgroundColor = Color.Default;
            incorrectCode.IsVisible = false;
        }
    }
}