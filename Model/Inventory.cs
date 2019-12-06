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
        private List<Product> AllAvailableProducts = new List<Product>();

        //Constructor
        public Inventory()
        {
            //Helper method to add items to database
            var Create = Task.Run(() => DataCreator());
            Create.Wait();

            //Reads from file async
            ReadData();
            
            
        }

        //Methods
        public List<Product> All()
        {
            return AllAvailableProducts;
        }

        private void ReadData()
        {
            var ReadTask = Task.Run(()=>ReadFile());
            ReadTask.Wait();
            string Text = ReadTask.Result;


            string[] line = Text.Split(";");
            for (int i = 0; i < line.Count() - 3; i++)
            {

                Product p = new Product(line[i], line[i + 1], double.Parse(line[i + 2]), line[i + 3]);
                AllAvailableProducts.Add(p);

                i = i + 3;
            }
            
            
        }

        private async Task<string> ReadFile()
        {
            string rawtext;
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile DataFile = await storageFolder.CreateFileAsync("Data.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
            var stream = await DataFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            ulong size = stream.Size;
            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    rawtext = dataReader.ReadString(numBytesLoaded);
                    
                }
            }
            return rawtext;
        }

       
        private async void dbError()  //File read error message
        {
            var messageDialog = new MessageDialog("Database error.");
            await messageDialog.ShowAsync();
        }

        private async Task DataCreator()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile DataFile = await storageFolder.CreateFileAsync("Data.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            string ImageFolder = "Assets/Products/";
            //Copy paste this to add items
            await Windows.Storage.FileIO.WriteTextAsync(DataFile
                ,"The Beast;"+ImageFolder+"pz_Beast"+".png;50;Pepperoni, Marinara, Mozarella;"
                + "Chicago Bold Fold;" + ImageFolder + "pz_Chicago" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Chorus Spice;" + ImageFolder + "pz_Chorus" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Godspell Beef Load;" + ImageFolder + "pz_Godspell" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Gypsy Euro;" + ImageFolder + "pz_Gypsy" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Mamma Mia;" + ImageFolder + "pz_MamaMia" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Phantom;" + ImageFolder + "pz_Phantom" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Poppin' BBQ;" + ImageFolder + "pz_Popping" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Tarzan Tikka;" + ImageFolder + "pz_Tarzan" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Westside Garlic;" + ImageFolder + "pz_WestSide" + ".png;50;Pepperoni, Marinara, Mozarella;"
                + "Wicked Blend;" + ImageFolder + "pz_Wicked" + ".png;50;Pepperoni, Marinara, Mozarella;"
               
                );


        }
    }
}
