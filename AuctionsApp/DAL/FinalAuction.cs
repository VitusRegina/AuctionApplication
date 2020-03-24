using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public class FinalAuction
    {
        public FinalAuction() { }

        public FinalAuction(int id, int n, int d)
        {
            ID = id;
            Startprice = n;
            ThingID = d;
            ActualPrice = n;
        }
        public FinalAuction(int id, int n, int d, string na, string de, int ap)
        {
            ID = id;
            Startprice = n;
            ThingID = d;
            ActualPrice = ap;
            ThingName = na;
            ThingDescription = de;
        }

        public int ID { get; set; }
        public int Startprice { get; set; }
        public int ThingID { get; set; }

        public string ThingName { get; set; }
        public string ThingDescription { get; set; }
        public int ActualPrice { get; set; }
    }
}
