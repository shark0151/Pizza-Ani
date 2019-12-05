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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza_Ani_Time.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactUs : Page
    {
        public ContactUs()
        {
            this.InitializeComponent();
        }

        private void SendMail_Click(object sender, RoutedEventArgs e)
        {
            this.InitializeComponent();
        }


        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            this.InitializeComponent();
            Thanks();
        }
        private async void Thanks()
        {
            var messageDialog = new MessageDialog("Thank you!");
            await messageDialog.ShowAsync();
        }
    }
}
