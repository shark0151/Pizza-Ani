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
            //Helper method to add items to database
            DataCreator();

            //Reads from file async
            ReadData();
            
        }

        //Methods
        public List<Product> All()
        {
            return AllAvailableProducts;
        }

        private async void ReadData()
        {
            var ReadTask = ReadFile();
            string Text = await ReadTask;

            try
            {
                string[] line = Text.Split(";");
                for (int i = 0; i < line.Count(); i++)
                {
                    Product p = new Product(line[i], line[i + 1], double.Parse(line[i + 2]), line[i + 3]);
                    AllAvailableProducts.Add(p);
                    i = i + 3;
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
            var messageDialog = new MessageDialog("Database error.");
            await messageDialog.ShowAsync();
        }

        private async void DataCreator()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //Overwrites existing files
            Windows.Storage.StorageFile DataFile = await storageFolder.CreateFileAsync("Data.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            //Copy paste this to add items
            await Windows.Storage.FileIO.WriteTextAsync(DataFile, "pizza;;22;none;");
        }
    }
}
