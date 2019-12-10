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
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;
using Pizza_Ani_Time.ViewModel;
using Pizza_Ani_Time.Model;
using Windows.UI.Text;
using Windows.UI.Popups;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.UI.Animations.Behaviors;
using Microsoft.Xaml.Interactivity;
using Color = System.Drawing.Color;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza_Ani_Time.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductPage : Page
    {
        public PizzaViewModel viewModel;

        private void CreateProductLayout(Product item)
        {
            Grid Main = new Grid();
            Grid blurGrid = new Grid();
            Blur blur = new Blur { Value = 10, Delay = 0, Duration = 0, AutomaticallyStart = true };
            blur.Attach(blurGrid);
            Grid.SetRowSpan(blurGrid, 2);
            blurGrid.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(153, 153, 153, 153));
            Main.Children.Add(blurGrid);

            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            Main.RowDefinitions.Add(row0);
            Main.RowDefinitions.Add(row1);

            Grid imageGrid = new Grid();
            Image image = new Image { Source = new BitmapImage(new Uri("ms-appx:///" + item.Image)) };
            imageGrid.Children.Add(image);
            imageGrid.Padding = new Thickness(0, 10, 0, 0);
            Grid.SetRow(imageGrid, 0);
            Main.Children.Add(imageGrid);

            Grid TextFields = new Grid();
            Grid.SetRow(TextFields, 1);
            RowDefinition trow0 = new RowDefinition();
            RowDefinition trow1 = new RowDefinition();
            RowDefinition trow2 = new RowDefinition();
            RowDefinition trow3 = new RowDefinition();
            TextFields.RowDefinitions.Add(trow0);
            TextFields.RowDefinitions.Add(trow1);
            TextFields.RowDefinitions.Add(trow2);
            TextFields.RowDefinitions.Add(trow3);
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

            Button toCart = new Button { Content = "Add To Cart" };
            toCart.Click += AddToCart_Click;
            toCart.HorizontalAlignment = HorizontalAlignment.Stretch;
            toCart.VerticalAlignment = VerticalAlignment.Stretch;
            toCart.DataContext = item;  //what we want te get when pressing button
            toCart.Foreground = new SolidColorBrush(Colors.White);
            toCart.CornerRadius = new CornerRadius(0, 0, 10, 10);

            TextFields.Children.Add(price);
            TextFields.Children.Add(name);
            TextFields.Children.Add(description);
            TextFields.Children.Add(toCart);
            Grid.SetRow(price, 0);
            Grid.SetRow(name, 1);
            Grid.SetRow(description, 2);
            Grid.SetRow(toCart, 3);
            Main.CornerRadius = new CornerRadius(10);

            ProductGrid.Children.Add(Main);


        }

        private void CreatePromoLayout(Product item)
        {
            Grid Main = new Grid { CornerRadius = new CornerRadius(10) };
            Grid blurGrid = new Grid();
            Blur blur = new Blur { Value = 10, Delay = 0, Duration = 0, AutomaticallyStart = true };
            blur.Attach(blurGrid);
            Grid.SetRowSpan(blurGrid, 5);
            blurGrid.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(153, 153, 153, 153));
            Main.Children.Add(blurGrid);

            Grid myGrid = new Grid();
            RowDefinition r1 = new RowDefinition();
            RowDefinition r2 = new RowDefinition { Height = GridLength.Auto };
            RowDefinition r3 = new RowDefinition { Height = GridLength.Auto };
            RowDefinition r4 = new RowDefinition { Height = GridLength.Auto };
            RowDefinition r5 = new RowDefinition { Height = GridLength.Auto };
            myGrid.RowDefinitions.Add(r1);
            myGrid.RowDefinitions.Add(r2);
            myGrid.RowDefinitions.Add(r3);
            myGrid.RowDefinitions.Add(r4);
            myGrid.RowDefinitions.Add(r5);
            myGrid.Height = 450;
            myGrid.Padding = new Thickness(0, 10, 0, 0);
            Main.Children.Add(myGrid);

            Image Image = new Image { Source = new BitmapImage(new Uri("ms-appx:///"+ item.Image)) };
            Grid imageGrid = new Grid();
            imageGrid.HorizontalAlignment = HorizontalAlignment.Center;
            imageGrid.VerticalAlignment = VerticalAlignment.Center;
            imageGrid.Children.Add(Image);
            
            imageGrid.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 255));
            imageGrid.CornerRadius = new CornerRadius(5);
            Grid.SetRow(imageGrid, 0);
            myGrid.Children.Add(imageGrid);

            TextBlock name = new TextBlock
            {
                Text = item.Name,
                Foreground = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(0, 10, 0, 10)
            };
            Grid.SetRow(name, 1);
            myGrid.Children.Add(name);

            TextBlock description = new TextBlock
            {
                Text = item.Details,
                Foreground = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(0, 10, 0, 10)
            };
            Grid.SetRow(description, 2);
            myGrid.Children.Add(description);

            TextBlock price = new TextBlock
            {
                Text = item.Price.ToString() + " kr",
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(0, 10, 0, 10)
            };
            Grid.SetRow(price, 3);
            myGrid.Children.Add(price);

            Button toCartButton = new Button
            {
                Content = "Add to cart",
                Foreground = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(0, 10, 0, 10),
                CornerRadius = new CornerRadius(0, 0, 10, 10),

            };
            Grid.SetRow(toCartButton, 4);
            toCartButton.Click += AddToCart_Click;
            toCartButton.DataContext = item; //important

            myGrid.Children.Add(toCartButton);
            
            Promotions.Children.Add(Main);
        }
        public ProductPage()
        {
            this.InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Product> List = viewModel.GetInventory();
            
            //check for empty
            //Product page
            try
            {
                foreach (var item in List)
                {
                    //split by category
                    if (item.Category == "Pizza")
                        CreateProductLayout(item);
                    else if (item.Category == "Drink")
                        CreateProductLayout(item);
                    else if (item.Category == "Promo")
                        CreatePromoLayout(item);

                }
            }
            catch
            {
                LayoutError();
            }

            
        }
        private async void LayoutError()  //Error message
        {
            var messageDialog = new MessageDialog("Failed to crate layout");
            await messageDialog.ShowAsync();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            //Get the product from the button as a product object;
            Product content = (sender as Button).DataContext as Product;

            viewModel.AddItemToCart(content);
        }
    }
}
