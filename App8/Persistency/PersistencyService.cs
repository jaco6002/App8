using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using App8.Model;
using Newtonsoft.Json;

namespace App8.Persistency
{
    class PersistencyService
    {
        private static string jsonFileName = "EventsAsJson1.dat";

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> Events)
        {
            string eventsJsonString = JsonConvert.SerializeObject(Events);
            SerializeEventsFileAsync(eventsJsonString, jsonFileName);
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(jsonFileName);
            if (eventsJsonString != null)
                return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
            return null;

        }

        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, eventsString);
        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {

                MessageDialogHelper.Show("Loading for the first time? Try Adding and Save some Events before you are trying to Load Events!", "File not found!");
                return null;
            }
        
        }
        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }
    }
}
