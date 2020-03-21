using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public class FinalThing
    {
        public FinalThing() {}
        
        public FinalThing(int id,string n,string d)
        {
            ID = id;
            Name = n;
            Desccription = d;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Desccription { get; set; }
    }
}
