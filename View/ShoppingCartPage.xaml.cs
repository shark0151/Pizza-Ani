using Microsoft.Toolkit.Uwp.UI.Animations.Behaviors;
using Pizza_Ani_Time.Model;
using Pizza_Ani_Time.ViewModel;
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Pizza_Ani_Time.View
{
    public sealed partial class ShoppingCartPage : Page
    {
        public PizzaViewModel viewModel;
        private void CreateProductLayout(Product item)
        {
            Grid mainMain = new Grid()
            {
                CornerRadius = new CornerRadius(10)
            };
            Grid Main = new Grid()
            {
                Padding = new Thickness(10)
            };
            Grid blurGrid = new Grid()
            {
                Background = new SolidColorBrush(Windows.UI.Color.FromArgb(153, 153, 153, 153))
            };
            Blur blur = new Blur { Value = 10, Delay = 0, Duration = 0, AutomaticallyStart = true };
            blur.Attach(blurGrid);
            Grid.SetColumnSpan(blurGrid, 6);

            mainMain.Children.Add(blurGrid);
            mainMain.Children.Add(Main);

            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition { Width = new GridLength(200) };
            Main.ColumnDefinitions.Add(col0);
            Main.ColumnDefinitions.Add(col1);
            Main.ColumnDefinitions.Add(col2);
            Main.ColumnDefinitions.Add(col3);
            Main.ColumnDefinitions.Add(col4);
            Main.ColumnDefinitions.Add(col5);

            Image image = new Image { Source = new BitmapImage(new Uri("ms-appx:///" + item.Image)) };
            Main.Children.Add(image);
            Grid.SetColumn(image, 0);

            Grid TextFields = new Grid();
            Grid.SetColumn(TextFields, 1);
            Grid.SetColumnSpan(TextFields, 2);
            RowDefinition trow0 = new RowDefinition();
            RowDefinition trow1 = new RowDefinition();

            TextFields.RowDefinitions.Add(trow0);
            TextFields.RowDefinitions.Add(trow1);

            Main.Children.Add(TextFields);

            TextBlock price = new TextBlock
            {
                Text = item.Price.ToString() + "kr",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.White)
            };

            TextBlock name = new TextBlock
            {
                Text = item.Name,
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontWeight = FontWeights.SemiLight,
                Foreground = new SolidColorBrush(Colors.White)
            };

            TextBlock description = new TextBlock
            {
                Text = item.Details,
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontWeight = FontWeights.Light,
                Foreground = new SolidColorBrush(Colors.White)
            };

            Button removeFromCart = new Button
            {
                Content = "Remove From Cart",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                CornerRadius = new CornerRadius(5),
                Foreground = new SolidColorBrush(Colors.White)
            };
            removeFromCart.Click += RemoveItem_Click;
            removeFromCart.DataContext = item;  //what we want te get when pressing button

            TextFields.Children.Add(name);
            TextFields.Children.Add(description);
            Main.Children.Add(price);
            Main.Children.Add(removeFromCart);

            Grid.SetRow(name, 0);
            Grid.SetRow(description, 1);

            Grid.SetColumn(price, 4);
            Grid.SetColumn(removeFromCart, 5);

            ListViewItem listViewItem = new ListViewItem
            {
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                MaxHeight = 200,
                Padding = new Thickness(5),
                Content = mainMain
            };
            ShoppingList.Items.Add(listViewItem);


        }

        private void CreateEmptyLayout(string message)
        {
            if (Cart.Children.Count < 3)
            {
                Grid mainMain = new Grid()
                {
                    CornerRadius = new CornerRadius(10),
                    Margin = new Thickness(100)

                };
                Grid Main = new Grid()
                {
                    Padding = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center

                };
                Grid blurGrid = new Grid()
                {
                    Background = new SolidColorBrush(Windows.UI.Color.FromArgb(150, 150, 150, 150))
                };
                Blur blur = new Blur { Value = 10, Delay = 0, Duration = 0, AutomaticallyStart = true };
                blur.Attach(blurGrid);


                TextBlock text = new TextBlock
                {
                    Text = message,
                    FontSize = 30,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    FontWeight = FontWeights.SemiLight,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                Main.Children.Add(text);
                mainMain.Children.Add(blurGrid);
                mainMain.Children.Add(Main);
                Cart.Children.Add(mainMain);
            }


        }
        public ShoppingCartPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (viewModel.CartNumber < 1)
                {
                    CreateEmptyLayout("Nothing here");
                }

                foreach (var item in viewModel.GetCart())
                {
                    CreateProductLayout(item);

                }

            }
            catch
            {
                LayoutError();
            }
            Total.DataContext = viewModel;
        }

        private async void LayoutError()  //Error message
        {
            var messageDialog = new MessageDialog("Failed to crate layout");
            await messageDialog.ShowAsync();
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            //Get the product from the button as a product object;
            Product content = (sender as Button).DataContext as Product;
            viewModel.RemoveItemFromCart(content);
            foreach (ListViewItem item in ShoppingList.Items)
            {
                if (item == (((sender as Button).Parent as Grid).Parent as Grid).Parent)
                {
                    ShoppingList.Items.Remove(item);
                }
            }
        }

        private void Checkout_OnClick(object sender, RoutedEventArgs e)
        {
            if (ShoppingList.Items.Count!=0)
            {
                viewModel.CreateOrder();
                viewModel.DeleteShoppingCart();
                ShoppingList.Items.Clear();
                CreateEmptyLayout("Thank You!");
            }
            else
            {
                EmptyError();
            }
        }

        private void EmptyCart_OnClick(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteShoppingCart();
            ShoppingList.Items.Clear();
            CreateEmptyLayout("Cart Emptied");
        }

        private async void EmptyError()
        {
            MessageDialog md = new MessageDialog("Cart is empty!");
            await md.ShowAsync();
        }
    }
}
