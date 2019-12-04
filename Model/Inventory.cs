using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using  Windows.UI.Popups;

namespace Pizza_Ani_Time.Model
{
    class Inventory
    {
        public static List<Product> AllAvailableProducts = new List<Product>();

        public Inventory()
        {
            
            AllAvailableProducts.Add(new Product("Pizza1", "", 50, "default pizza"));
            AllAvailableProducts.Add(new Product("Pizza2", "", 50, "default pizza"));
            AllAvailableProducts.Add(new Product("Pizza3", "", 50, "default pizza"));
            AllAvailableProducts.Add(new Product("Pizza4", "", 50, "default pizza"));
            AllAvailableProducts.Add(new Product("Pizza5", "", 50, "default pizza"));
            AllAvailableProducts.Add(new Product("Pizza6", "", 50, "default pizza"));
            /*
            try //make async
            {
                StreamReader sr = File.OpenText("");
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    Product p = new Product(line[0], line[1], double.Parse(line[2]), line[3]);
                    AllAvailableProducts.Add(p);
                }
                sr.Close();
            }
            catch
            {
                dbError();
            }
            */
        }

        public List<Product> All()
        {
            return AllAvailableProducts;
        }

        private async void dbError()
        {
            var messageDialog = new MessageDialog("Database error.");
            await messageDialog.ShowAsync();
        }
    }
}
