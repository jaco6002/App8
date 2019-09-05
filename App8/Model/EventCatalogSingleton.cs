using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App8.Persistency;

namespace App8.Model
{
    public class EventCatalogSingleton
    {
        static EventCatalogSingleton _instance=null;
        private ObservableCollection<Event> _eventCollection;

        private EventCatalogSingleton()
        {
            //Event Event1=new Event(1,"festival","musik","roskilde",new DateTime());
            //Event Event2 = new Event(2, "tour", "museumstur", "roskilde", new DateTime());
            _eventCollection=new ObservableCollection<Event>();
            //_eventCollection.Add(Event1);
            //_eventCollection.Add(Event2);
            LoadEventsAsync();
        }

        public static EventCatalogSingleton Instance
        {
            get
            {
               return _instance ?? (_instance=new EventCatalogSingleton()); }
        }

        public ObservableCollection<Event> EventCollection
        {
            get { return _eventCollection; }
            set { _eventCollection = value; }
        }

        public void AddEvent(Event e)
        {
            EventCollection.Add(e);
            PersistencyService.SaveEventsAsJsonAsync(EventCollection);
        }

        public async void LoadEventsAsync()
        {
            List<Event> newlist = await PersistencyService.LoadEventsFromJsonAsync();
            if (newlist != null)
            {
                ObservableCollection<Event> EventC = new ObservableCollection<Event>(newlist);
                foreach (Event e in EventC)
                {
                    _eventCollection.Add(e);
                }
                
            }
        }
        public void RemoveEvent(Event e)
        {
            if (EventCollection.Contains(e))
            {
                 EventCollection.Remove(e);
            }
            PersistencyService.SaveEventsAsJsonAsync(EventCollection);
        }
    }
}
