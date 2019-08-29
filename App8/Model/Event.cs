using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    public class Event
    {
        private int _id;
        private string _name;
        private string _describtion;
        private string _place;
        private DateTime _dateTime;

        public Event(int id, string name, string describtion, string place, DateTime dateTime)
        {
            _id = id;
            _name = name;
            _describtion = describtion;
            _place = place;
            _dateTime = dateTime;
        }

        public override string ToString()
        {
            return $"navn: {_name}  id:{_id}  time: {_dateTime.Date}";
        }

        public int ID
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _describtion; }
        }

        public string Place
        {
            get { return _place; }
        }

        public DateTime DateTime
        {
            get { return _dateTime; }
        }

    }
}
