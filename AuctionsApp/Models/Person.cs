using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Name { get; set; }
       // [NotMapped]
       // public List<Thing> Things { get; set; }
       // [NotMapped]
       // public List<Bid> Bids { get; set; }
    }
}
