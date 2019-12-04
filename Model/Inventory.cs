using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Pizza_Ani_Time.Model
{
    class Inventory
    {
        //Instance Fields
        public List<Product> AllAvailableProducts { get; }

        //Constructor
        public Inventory()
        {
            //File read
            try
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
            //File read error
            catch
            {
                dbError();
            }
        }

        //File read error message
        private async void dbError()
        {
            var messageDialog = new MessageDialog("Database error.");
            await messageDialog.ShowAsync();
        }
    }
}
