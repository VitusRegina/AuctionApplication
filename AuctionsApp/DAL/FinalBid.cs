using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public class FinalBid
    {
        public FinalBid() { }

        public FinalBid(int id, int s)
        {
            ID = id;
            Sum = s;
        }

        public int ID { get; set; }
        public int Sum { get; set; }
    }
}
