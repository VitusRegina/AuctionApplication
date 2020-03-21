using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.Models
{
    public class Auction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Startprice { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Boolean? Sikeres { get; set; }
        public int ThingID { get; set; }
        public Thing Thing { get; set; }
       // [NotMapped]
        //public List<Bid> Bids { get; set; }

    }
}
