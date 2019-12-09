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
using System.Drawing;
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
        public ProductPage()
        {
            this.InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Product> List = viewModel.GetInventory();
            List<Product> promoList = new List<Product>
            {
                new Product("Offer 1", "", 70, "Buy 1 pizza and 1 drink with a discount","Promo"),
                new Product("Offer 2", "", 130, "Buy 2 pizzas and 2 drinks with a discount","Promo"),
            };
            //check for empty
            //Product page
            try
            {
                foreach (var item in List)
                {
                    if (item.Category == "Pizza")
                        CreateProductLayout(item);

                }

                foreach (var item in List)
                {
                    if (item.Category == "Drink")
                        CreateProductLayout(item);

                }

                ProductGrid.UpdateLayout(); //might not be needed but whatever
            }
            catch
            {
                LayoutError();
            }

            //Promo page
            foreach (var v in promoList)
            {
                Grid blurGrid = new Grid();
                Blur blur = new Blur { Value = 10, Delay = 0, Duration = 0, AutomaticallyStart = true };
                blur.Attach(blurGrid);
                Grid.SetRowSpan(blurGrid, 5);
                blurGrid.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(153, 153, 153, 153));

                Grid myGrid = new Grid();
                RowDefinition r1 = new RowDefinition();
                RowDefinition r2 = new RowDefinition();
                RowDefinition r3 = new RowDefinition();
                RowDefinition r4 = new RowDefinition();
                RowDefinition r5 = new RowDefinition();
                myGrid.RowDefinitions.Add(r1);
                myGrid.RowDefinitions.Add(r2);
                myGrid.RowDefinitions.Add(r3);
                myGrid.RowDefinitions.Add(r4);
                myGrid.RowDefinitions.Add(r5);
                myGrid.Children.Add(blurGrid);
                myGrid.Height = 500;

                Image pic = new Image();


                Grid.SetRow(pic, 0);
                TextBlock t1 = new TextBlock { Text = v.Name, Foreground = new SolidColorBrush(Colors.White) };
                t1.VerticalAlignment = VerticalAlignment.Center;
                t1.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(t1, 1);
                myGrid.Children.Add(t1);
                TextBlock t2 = new TextBlock { Text = v.Details, Foreground = new SolidColorBrush(Colors.White) };
                t2.VerticalAlignment = VerticalAlignment.Center;
                t2.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(t2, 2);
                myGrid.Children.Add(t2);
                TextBlock t3 = new TextBlock
                {
                    Text = v.Price.ToString() + " kr",
                    Foreground = new SolidColorBrush(Colors.White),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center

                };
                Grid.SetRow(t3, 3);
                myGrid.Children.Add(t3);
                Button b = new Button();
                b.VerticalAlignment = VerticalAlignment.Center;
                b.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(b, 4);
                b.Content = "Add to cart";
                b.Foreground = new SolidColorBrush(Colors.White);
                b.CornerRadius = new CornerRadius(5);
                myGrid.Children.Add(b);
                Promotions.Children.Add(myGrid);

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
