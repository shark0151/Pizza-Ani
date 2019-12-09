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
            Blur blur=new Blur();
            blur.Value = 10;
            blur.Delay = 0;
            blur.Duration = 0;
            blur.AutomaticallyStart = true;
            blur.Attach(blurGrid);
            Grid.SetRowSpan(blurGrid,2);
            blurGrid.Background=new SolidColorBrush(Windows.UI.Color.FromArgb(153,153,153,153));
            Main.Children.Add(blurGrid);

            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            Main.RowDefinitions.Add(row0);
            Main.RowDefinitions.Add(row1);

            Grid imageGrid=new Grid();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("ms-appx:///" + item.Image));
            imageGrid.Children.Add(image);
            imageGrid.Padding = new Thickness(0,10,0,0);
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

            TextBlock price = new TextBlock();
            price.Text = item.Price.ToString() + "kr";
            price.FontSize = 20;
            price.HorizontalAlignment = HorizontalAlignment.Center;
            price.FontWeight = FontWeights.Bold;
            price.Foreground=new SolidColorBrush(Colors.White);

            TextBlock name = new TextBlock();
            name.Text = item.Name;
            name.FontSize = 30;
            name.HorizontalAlignment = HorizontalAlignment.Center;
            name.FontWeight = FontWeights.SemiLight;
            name.Foreground = new SolidColorBrush(Colors.White);

            TextBlock description = new TextBlock();
            description.Text = item.Details;
            description.FontSize = 20;
            description.HorizontalAlignment = HorizontalAlignment.Center;
            description.FontWeight = FontWeights.Light;
            description.Foreground = new SolidColorBrush(Colors.White);

            Button toCart = new Button();
            toCart.Content = "Add To Cart";
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
                new Product("Offer 3", "", 200, "DISCOUNT","Promo")
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
                Grid myGrid = new Grid();
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(200);
                ColumnDefinition c2 = new ColumnDefinition();
                c2.Width = new GridLength(100);
                ColumnDefinition c3 = new ColumnDefinition();
                c3.Width = new GridLength(300);
                ColumnDefinition c4 = new ColumnDefinition();
                c4.Width = new GridLength(100);
                ColumnDefinition c5 = new ColumnDefinition();
                c5.Width = new GridLength(100);
                myGrid.ColumnDefinitions.Add(c1);
                myGrid.ColumnDefinitions.Add(c2);
                myGrid.ColumnDefinitions.Add(c3);
                myGrid.ColumnDefinitions.Add(c4);
                myGrid.ColumnDefinitions.Add(c5);
                RowDefinition r = new RowDefinition();
                myGrid.RowDefinitions.Add(r);
                Image pic = new Image();

                pic.Stretch = Stretch.UniformToFill;
                Grid.SetColumn(pic, 0);
                TextBlock t1 = new TextBlock();
                t1.Text = v.Name;
                t1.Foreground = new SolidColorBrush(Colors.White);
                Grid.SetColumn(t1, 1);
                myGrid.Children.Add(t1);
                TextBlock t2 = new TextBlock();
                t2.Text = v.Details;
                t2.Foreground = new SolidColorBrush(Colors.White);
                Grid.SetColumn(t2, 2);
                myGrid.Children.Add(t2);
                TextBlock t3 = new TextBlock();
                t3.Text = v.Price.ToString() + " kr";
                t3.Foreground = new SolidColorBrush(Colors.White);
                Grid.SetColumn(t3, 3);
                myGrid.Children.Add(t3);
                Button b = new Button();
                Grid.SetColumn(b, 4);
                b.Content = "Add to cart";
                b.Foreground = new SolidColorBrush(Colors.White);
                myGrid.Children.Add(b);
                Promotions.Items.Add(myGrid);
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
