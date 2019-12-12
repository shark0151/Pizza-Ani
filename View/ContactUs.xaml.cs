using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

namespace Pizza_Ani_Time.View
{
    public sealed partial class ContactUs : Page
    {
        public ContactUs()
        {
            this.InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            this.InitializeComponent();
            if (name.Text != "" && email.Text != "" && message.Text != "")
            {
                Thanks();
                name.Text = "";
                email.Text = "";
                message.Text = "";
            }
            else
            {
                Empty();
            }
        }
        private async void Thanks()
        {
            var messageDialog = new MessageDialog("Thank you!");
            await messageDialog.ShowAsync();
        }

        private async void Empty()
        {
            MessageDialog messageDialog = new MessageDialog("Fill out all the fields!");
            await messageDialog.ShowAsync();
        }
    }
}
