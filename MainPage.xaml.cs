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

using Pizza_Ani_Time.View;

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
            Content.Navigate(typeof(PromotionsPage), null);
        }

        private void Pane_Click(object sender, RoutedEventArgs e)
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
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(PromotionsPage), e);

        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);

        }
        private void History_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);

        }
        private void Cart_Click(object sender, RoutedEventArgs e)
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

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmptyPage), e);
        }
    }
}
