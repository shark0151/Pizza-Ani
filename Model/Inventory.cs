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
            var Create = Task.Run(() => DataCreator(true));
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

            try
            {
                string[] line = Text.Split(";");
                for (int i = 0; i < line.Count() - 4; i++)
                {

                    Product p = new Product(line[i], line[i + 1], double.Parse(line[i + 2]), line[i + 3],line[i+4]);
                    AllAvailableProducts.Add(p);

                    i += 4;
                }
            }
            catch
            {
                dbError();
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
            var messageDialog = new MessageDialog("Failed to read from database");
            await messageDialog.ShowAsync();
        }

        private async Task DataCreator(bool shouldCreate)
        {
            if (shouldCreate)
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile DataFile = await storageFolder.CreateFileAsync("Data.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                string ImageFolder = "Assets/Products/";
                //Copy paste this to add items
                await Windows.Storage.FileIO.WriteTextAsync(DataFile
                    , "The Beast;" + ImageFolder + "pz_Beast" + ".png;45;Tomatoes, Mozzarella, Oregano;Pizza;"
                    + "Chicago Bold Fold;" + ImageFolder + "pz_Chicago" + ".png;50;Pepperoni, Marinara, Mozarella;Pizza;"
                    + "Chorus Spice;" + ImageFolder + "pz_Chorus" + ".png;50;Green Pepper, Mushroom, Onion, Ham;Pizza;"
                    + "Godspell Beef Load;" + ImageFolder + "pz_Godspell" + ".png;60;Salami, Olive, Pepper, Mushroom;Pizza;"
                    + "Gypsy Euro;" + ImageFolder + "pz_Gypsy" + ".png;55;Green Pepper, Red Pepper, Mushroom;Pizza;"
                    + "Mamma Mia;" + ImageFolder + "pz_MamaMia" + ".png;60;Salami, Olive, Mozarella;Pizza;"
                    + "Phantom;" + ImageFolder + "pz_Phantom" + ".png;45;Mushroom, Green Pepper, Olive;Pizza;"
                    + "Poppin' BBQ;" + ImageFolder + "pz_Popping" + ".png;65;Ham, Onion, Hot Pepper, BBQ sauce;Pizza;"
                    + "Tarzan Tikka;" + ImageFolder + "pz_Tarzan" + ".png;55;Ham, Onion, Extra Cheese;Pizza;"
                    + "Westside Garlic;" + ImageFolder + "pz_WestSide" + ".png;60;Red Pepper, Hot Pepper, Mushroom;Pizza;"
                    + "Wicked Blend;" + ImageFolder + "pz_Wicked" + ".png;55;Ham, Green Pepper, Olive;Pizza;"

                    + "Pepsi 0,33l;" + ImageFolder + "drk_Pepsi03l" + ".png;15;Refreshing drink;Drink;"
                    + "Pepsi 0,5l;" + ImageFolder + "drk_Pepsi05l" + ".png;20;Refreshing drink;Drink;"
                    + "Pepsi 2l;" + ImageFolder + "drk_Pepsi2l" + ".png;30;Refreshing drink;Drink;"
                    + "Fanta 0,33l;" + ImageFolder + "drk_Fanta03l" + ".png;15;Refreshing drink;Drink;"
                    + "Fanta 0,5l;" + ImageFolder + "drk_Fanta05l" + ".png;20;Refreshing drink;Drink;"
                    + "Fanta 2l;" + ImageFolder + "drk_Fanta2l" + ".png;30;Refreshing drink;Drink;"
                    + "Cola 0,33l;" + ImageFolder + "drk_Cola03l" + ".png;15;Refreshing drink;Drink;"
                    + "Cola 0,5l;" + ImageFolder + "drk_Cola05l" + ".png;20;Refreshing drink;Drink;"
                    + "Cola 2l;" + ImageFolder + "drk_Cola2l" + ".png;30;Refreshing drink;Drink;"
                    + "Sprite 0,33l;" + ImageFolder + "drk_Sprite03l" + ".png;15;Refreshing drink;Drink;"
                    + "Sprite 0,5l;" + ImageFolder + "drk_Sprite05l" + ".png;20;Refreshing drink;Drink;"
                    + "Sprite 2l;" + ImageFolder + "drk_Sprite2l" + ".png;30;Refreshing drink;Drink;"
                    + "Offer 1;" + ImageFolder + "pr_Offer1" + ".jpg;70;Buy 1 pizza and 1 drink;Promo;"
                    + "Offer 2;" + ImageFolder + "pr_Offer2" + ".jpg;130;Buy 2 pizzas and 2 drinks;Promo;"

                    );

            }

        }
    }
}
