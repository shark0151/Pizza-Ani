using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Animations.Behaviors;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Pizza_Ani_Time.Model;
using Pizza_Ani_Time.ViewModel;
using Windows.UI.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza_Ani_Time.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderHistory : Page
    {
        public PizzaViewModel viewModel;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CreateLayout();
        }

        private void CreateEmptyLayout()
        {
            if (activeOrders.Items.Count == 0)
            {
                noActive.Visibility = Visibility.Visible;
            }
            else
            {
                noActive.Visibility = Visibility.Collapsed;
            }

            if (recentOrders.Items.Count == 0)
            {
                noRecent.Visibility = Visibility.Visible;
            }
            else
            {
                noRecent.Visibility = Visibility.Collapsed;
            }


        }
        private void Create(string action,ListView destination,List<Order> source )
        {
            foreach (var order in source)
            {
                Grid Main = new Grid { CornerRadius = new CornerRadius(10), HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Center };
                Grid blurGrid = new Grid()
                {
                    Background = new SolidColorBrush(Windows.UI.Color.FromArgb(153, 153, 153, 153))
                };
                Blur blur = new Blur { Value = 10, Delay = 0, Duration = 0, AutomaticallyStart = true };
                blur.Attach(blurGrid);
                Main.Children.Add(blurGrid);

                //HeaderGrid
                //now overlayed on the expander menu -- because xaml
                Grid orderGrid = new Grid()
                {
                    Height = 40,
                    VerticalAlignment = VerticalAlignment.Top,
                    Padding = new Thickness(100, 0, 10, 0),
                };
                ColumnDefinition c1 = new ColumnDefinition { MinWidth = 100 };
                ColumnDefinition c2 = new ColumnDefinition { MinWidth = 100 };
                ColumnDefinition c3 = new ColumnDefinition { MinWidth = 200 };
                orderGrid.ColumnDefinitions.Add(c1);
                orderGrid.ColumnDefinitions.Add(c2);
                orderGrid.ColumnDefinitions.Add(c3);
                TextBlock date = new TextBlock { Text = order.date.ToShortDateString(), IsHitTestVisible = false, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White) };
                Grid.SetColumn(date, 0);
                orderGrid.Children.Add(date);
                TextBlock price = new TextBlock { Text = order.TotalPrice.ToString() + " kr", IsHitTestVisible = false, HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White) };
                Grid.SetColumn(price, 1);
                orderGrid.Children.Add(price);

                Button actionButton = new Button { Content = action, CornerRadius = new CornerRadius(5), HorizontalAlignment = HorizontalAlignment.Right, Width = 200, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White) };
                if(destination == activeOrders)
                {
                    actionButton.Click += Claim_Click;
                }
                else
                {
                    actionButton.Click += AddToCart_Click;
                }
                actionButton.DataContext = order;
                Grid.SetColumn(actionButton, 2);
                orderGrid.Children.Add(actionButton);

                //Content
                ListView itemsListView = new ListView();
                foreach (var item in order.Items)
                {
                    Grid itemsGrid = new Grid();
                    ColumnDefinition cd1 = new ColumnDefinition();
                    ColumnDefinition cd2 = new ColumnDefinition();
                    ColumnDefinition cd3 = new ColumnDefinition();
                    itemsGrid.ColumnDefinitions.Add(cd1);
                    itemsGrid.ColumnDefinitions.Add(cd2);
                    itemsGrid.ColumnDefinitions.Add(cd3);
                    Image image = new Image { Source = new BitmapImage(new Uri("ms-appx:///" + item.Image)) };
                    Grid.SetColumn(image, 0);
                    itemsGrid.Children.Add(image);
                    TextBlock t1 = new TextBlock { Text = item.Name, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White) };
                    Grid.SetColumn(t1, 1);
                    itemsGrid.Children.Add(t1);
                    TextBlock t2 = new TextBlock { Text = item.Price.ToString() + " kr", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White) };
                    Grid.SetColumn(t2, 2);
                    itemsGrid.Children.Add(t2);
                    ListViewItem listViewItem = new ListViewItem
                    {
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        MaxHeight = 200,
                        Padding = new Thickness(5),
                        Content = itemsGrid
                    };
                    itemsListView.Items.Add(listViewItem);
                }

                //Header
                Expander expander = new Expander()
                {
                    Header = "",
                    Content = itemsListView,
                    Background = new SolidColorBrush(Windows.UI.Color.FromArgb(0, 0, 0, 0)),
                    HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };

                Main.Children.Add(expander);
                Main.Children.Add(orderGrid);


                ListViewItem orderListItem = new ListViewItem
                {
                    HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Padding = new Thickness(5),
                    Content = Main,
                };
                destination.Items.Add(orderListItem);
            }
        }
        private void CreateLayout()
        {
            Create("Claim", activeOrders, viewModel.GetActiveOrders());
            Create("Add to cart", recentOrders, viewModel.GetRecentOrders());
            CreateEmptyLayout();
        }
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            //Get the product from the button as a product object;
            Order content = (sender as Button).DataContext as Order;
            foreach (Product item in content.Items)
            {
                viewModel.AddItemToCart(item);
            }
            //should display a message or go to cart
        }

        private void Claim_Click(object sender, RoutedEventArgs e)
        {
            //Get the product from the button as a product object;
            Order content = (sender as Button).DataContext as Order;
            viewModel.DeactivateOrder(content);
            Frame.Navigate(typeof(OrderHistory), e);
        }

        public OrderHistory()
        {
            this.InitializeComponent();
        }
    }
}
