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
using System.IO;
using Windows.UI.Xaml.Media.Imaging;
using Pizza_Ani_Time.ViewModel;
using Pizza_Ani_Time.Model;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Text;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza_Ani_Time.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductList : Page
    {
        private void CreateProductItem(Product item)
        {
            
            Grid Main = new Grid();
            
            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            Main.RowDefinitions.Add(row0);
            Main.RowDefinitions.Add(row1);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("ms-appx:///"+ item.Image));
            Main.Children.Add(image);
            Grid.SetRow(image, 0);

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
            price.Text = item.Price.ToString()+"kr";
            price.FontSize = 20;
            price.HorizontalAlignment = HorizontalAlignment.Center;
            price.FontWeight = FontWeights.Bold;

            TextBlock name = new TextBlock();
            name.Text = item.Name;
            name.FontSize = 30;
            name.HorizontalAlignment = HorizontalAlignment.Center;
            name.FontWeight = FontWeights.SemiLight;

            TextBlock description = new TextBlock();
            description.Text = item.Details;
            description.FontSize = 20;
            description.HorizontalAlignment = HorizontalAlignment.Center;
            description.FontWeight = FontWeights.Light;

            Button toCart = new Button();
            toCart.Content = "Add To Cart";
            toCart.Click += AddToCart_Click;
            toCart.HorizontalAlignment = HorizontalAlignment.Stretch;
            toCart.VerticalAlignment = VerticalAlignment.Stretch;

            TextFields.Children.Add(price);
            TextFields.Children.Add(name);
            TextFields.Children.Add(description);
            TextFields.Children.Add(toCart);
            Grid.SetRow(price, 0);
            Grid.SetRow(name, 1);
            Grid.SetRow(description, 2);
            Grid.SetRow(toCart, 3);

            ProductGrid.Children.Add(Main);


        }
        public ProductList()
        {
            this.InitializeComponent();
            PizzaViewModel viewModel = new PizzaViewModel();
            List<Product> x = viewModel.GetInventory();

            List<Product> promoList = new List<Product>
            {
                new Product("Offer 1", "", 70, "Buy 1 pizza and 1 drink with a discount"),
                new Product("Offer 2", "", 130, "Buy 2 pizzas and 2 drinks with a discount"),
                new Product("Offer 3", "", 200, "DISCOUNT")
            };
            List<Product> List = viewModel.GetInventory();
            //check for empty

            try
            {
                
                foreach (var item in List)
                {
                    CreateProductItem(item);
                    
                }
                ProductGrid.UpdateLayout();
            }
            catch 
            {

            }
            catch { }

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
                Grid.SetColumn(t1, 1);
                myGrid.Children.Add(t1);
                TextBlock t2 = new TextBlock();
                t2.Text = v.Details;
                Grid.SetColumn(t2, 2);
                myGrid.Children.Add(t2);
                TextBlock t3 = new TextBlock();
                t3.Text = v.Price.ToString()+" kr";
                Grid.SetColumn(t3, 3);
                myGrid.Children.Add(t3);
                Button b=new Button();
                Grid.SetColumn(b,4);
                b.Content = "Add to cart";
                myGrid.Children.Add(b);
                Promotions.Items.Add(myGrid);
            }
            /*
            //example of adding xaml from c#
            Windows.UI.Xaml.Controls.Button buttonfromcode= new Button();
            buttonfromcode.Content = "Press me";
           
            Grid.Children.Add(buttonfromcode);
            Grid.VerticalAlignment = VerticalAlignment.Top;
            */


        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
