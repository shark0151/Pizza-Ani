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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pizza_Ani_Time
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SideMenu.DataContext = SideMenu.CompactPaneLength;
            Content.Navigate(typeof(EmptyPage), null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SideMenu.IsPaneOpen = !SideMenu.IsPaneOpen;
            if (SideMenu.IsPaneOpen == true)
            {
                SideMenu.DataContext = SideMenu.OpenPaneLength;
            }
            else
            {
                SideMenu.DataContext = SideMenu.CompactPaneLength;
            }

        }
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);

        }
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);

        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);

        }
    }
}
