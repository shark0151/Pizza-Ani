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
            DataCreator();

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

        private async void DataCreator()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //Overwrites existing files
            Windows.Storage.StorageFile DataFile = await storageFolder.CreateFileAsync("Data.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            //Copy paste this to add items
            await Windows.Storage.FileIO.WriteTextAsync(DataFile, "pizza1; ;22;none;");
            
        }
    }
}
