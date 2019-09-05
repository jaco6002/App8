using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App8.Converter;
using App8.Model;
using App8.ViewModel;

namespace App8.Handler
{
    public class EventHandler
    {
        public EventViewModel ViewModel;

        public EventHandler(EventViewModel vm)
        {
            ViewModel = vm;
        }

        public void CreateEvent()
        {
            DateTime date = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel.Date, ViewModel.Time);
            Event NewEvent = new Event(ViewModel.Id,ViewModel.Name,ViewModel.Description,ViewModel.Place, date);
            EventCatalogSingleton.Instance.AddEvent(NewEvent);
        }

        public void DeleteEvent()
        {
            EventCatalogSingleton.Instance.RemoveEvent(EventViewModel.SelectedEvent);
        }

        public void SetSelectedEvent(Event ev)
        {
            EventViewModel.SelectedEvent = ev;
        }
    }
}
