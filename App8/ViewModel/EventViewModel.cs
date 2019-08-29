using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App8.Annotations;
using App8.Common;
using App8.Handler;
using App8.Model;

namespace App8.ViewModel
{
    public class EventViewModel { 

        private int _id;
        private string _name;
        private string _description;
        private string _place;
        private DateTimeOffset _date;
        private TimeSpan _time;
        public EventCatalogSingleton EventCatalog { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public EventViewModel()
        {
            Events = EventCatalogSingleton.Instance.EventCollection;
            EventCatalog = EventCatalogSingleton.Instance;
            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0,0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            EventHandler=new Handler.EventHandler(this);
            CreateEventCommand = new RelayCommand(CreateEventMethod);
            EventCatalog.LoadEventsAsync();
        }

        public void CreateEventMethod()
        {
            EventHandler.CreateEvent();
        }

        public int Id
        {
            get { return _id;}
            set { _id = value;}
        }
        public string Name
        {
            get { return _name;}
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Place {
            get { return _place; }
            set { _place = value; }
        }
        public DateTimeOffset Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public static Event SelectedEvent { get; set; }
        

        public Handler.EventHandler EventHandler { get; set; }
        public ICommand CreateEventCommand { get; set; }


        
    }
}
