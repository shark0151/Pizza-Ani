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

using Pizza_Ani_Time.ViewModel;
using Pizza_Ani_Time.Model;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza_Ani_Time.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductList : Page
    {
        public ProductList()
        {
            this.InitializeComponent();
            PizzaViewModel viewModel = new PizzaViewModel();
            List<Product> x = viewModel.GetInventory();
            //check for empty
            try
            {
                foreach (var y in x)
                {
                    ListViewItem asda = new ListViewItem();
                    asda.Content = y.Name;

                    List.Items.Add(asda);
                }
            }
            catch
            {

            }
            /*
            //example of adding xaml from c#
            Windows.UI.Xaml.Controls.Button buttonfromcode= new Button();
            buttonfromcode.Content = "Press me";
           
            Grid.Children.Add(buttonfromcode);
            Grid.VerticalAlignment = VerticalAlignment.Top;
            */


        }
    }
}
