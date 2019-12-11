﻿using System;
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

        private void CreateLayout()
        {
            foreach (var order in viewModel.GetActiveOrders())
            {
                Grid Main = new Grid { CornerRadius = new CornerRadius(10), HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
                Grid blurGrid = new Grid()
                {
                    Background = new SolidColorBrush(Windows.UI.Color.FromArgb(153, 153, 153, 153))
                };
                Blur blur = new Blur { Value = 10, Delay = 0, Duration = 0, AutomaticallyStart = true };
                blur.Attach(blurGrid);
                Main.Children.Add(blurGrid);
                Expander expander = new Expander { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
                Grid orderGrid = new Grid();
                ColumnDefinition c1 = new ColumnDefinition { Width = new GridLength(300) };
                ColumnDefinition c2 = new ColumnDefinition { Width = new GridLength(300) };
                ColumnDefinition c3 = new ColumnDefinition { Width = new GridLength(300) };
                orderGrid.ColumnDefinitions.Add(c1);
                orderGrid.ColumnDefinitions.Add(c2);
                orderGrid.ColumnDefinitions.Add(c3);
                TextBlock date = new TextBlock { Text = order.date.ToShortDateString(), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center };
                Grid.SetColumn(date, 0);
                orderGrid.Children.Add(date);
                TextBlock price = new TextBlock { Text = order.TotalPrice.ToString() + " kr", HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center };
                Grid.SetColumn(price, 1);
                orderGrid.Children.Add(price);
                Button claim = new Button { Content = "Add to cart", CornerRadius = new CornerRadius(5), HorizontalAlignment = HorizontalAlignment.Right, Width = 200, VerticalAlignment = VerticalAlignment.Center };
                Grid.SetColumn(claim, 2);
                orderGrid.Children.Add(claim);
                expander.Header = orderGrid;
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
                    TextBlock t1 = new TextBlock { Text = item.Name, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center };
                    Grid.SetColumn(t1, 1);
                    itemsGrid.Children.Add(t1);
                    TextBlock t2 = new TextBlock { Text = item.Price.ToString() + " kr" };
                    Grid.SetColumn(t2, 2);
                    itemsGrid.Children.Add(t2);
                    itemsListView.Items.Add(itemsGrid);
                }
                expander.Content = itemsListView;
                Main.Children.Add(expander);
                activeOrders.Items.Add(Main);
            }

            foreach (var order in viewModel.GetRecentOrders())
            {
                Grid Main = new Grid { CornerRadius = new CornerRadius(10), HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
                Grid blurGrid = new Grid()
                {
                    Background = new SolidColorBrush(Windows.UI.Color.FromArgb(153, 153, 153, 153))
                };
                Blur blur = new Blur { Value = 10, Delay = 0, Duration = 0, AutomaticallyStart = true };
                blur.Attach(blurGrid);
                Main.Children.Add(blurGrid);
                Expander expander = new Expander { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Background = new SolidColorBrush(Colors.Transparent) };
                Grid orderGrid = new Grid();
                ColumnDefinition c1 = new ColumnDefinition();
                ColumnDefinition c2 = new ColumnDefinition();
                ColumnDefinition c3 = new ColumnDefinition();
                orderGrid.ColumnDefinitions.Add(c1);
                orderGrid.ColumnDefinitions.Add(c2);
                orderGrid.ColumnDefinitions.Add(c3);
                TextBlock date = new TextBlock { Text = order.date.ToShortDateString(), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center };
                Grid.SetColumn(date, 0);
                orderGrid.Children.Add(date);
                TextBlock price = new TextBlock { Text = order.TotalPrice.ToString(), HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center };
                Grid.SetColumn(price, 1);
                orderGrid.Children.Add(price);
                Button orderAll = new Button { Content = "Add to cart", HorizontalAlignment = HorizontalAlignment.Right, Width = 200, VerticalAlignment = VerticalAlignment.Center };
                Grid.SetColumn(orderAll, 2);
                orderGrid.Children.Add(orderAll);
                expander.Header = orderGrid;
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
                    Image image = new Image { Source = new BitmapImage(new Uri("ms-appx:///" + item.Image)), Stretch = Stretch.UniformToFill };
                    Grid.SetColumn(image, 0);
                    itemsGrid.Children.Add(image);
                    TextBlock t1 = new TextBlock { Text = item.Name, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center };
                    Grid.SetColumn(t1, 1);
                    itemsGrid.Children.Add(t1);
                    Button orderButton = new Button { Content = "Add to cart", CornerRadius = new CornerRadius(5), HorizontalAlignment = HorizontalAlignment.Right, Width = 200, DataContext = item, VerticalAlignment = VerticalAlignment.Center };
                    orderButton.Click += AddToCart_Click;
                    Grid.SetColumn(orderButton, 2);
                    itemsGrid.Children.Add(orderButton);
                    itemsListView.Items.Add(itemsGrid);
                }
                expander.Content = itemsListView;
                Main.Children.Add(expander);
                recentOrders.Items.Add(Main);
            }
        }
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            //Get the product from the button as a product object;
            Product content = (sender as Button).DataContext as Product;

            viewModel.AddItemToCart(content);
        }
        public OrderHistory()
        {
            this.InitializeComponent();
        }
    }
}
