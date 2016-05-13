using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerLib
{
    public class Room
    {
        public int ID { get; set; }
        public int MaxCount { get; set; }
        List<Group> _GroupList;
        public Room()
        {
            _GroupList = new List<Group>();
        }


    }
}
