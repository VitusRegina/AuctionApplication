using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.Models
{
    public class Bid
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Sum { get; set; }
        public int AuctionID { get; set; }
        public Auction Auction { get; set; }
        
        //public int PersonID { get; set; }
        [NotMapped]
        public Person Person { get; set; }
    }
}
