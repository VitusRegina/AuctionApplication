using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.Models
{
    public class Thing
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desccription { get; set; }
        public int PersonID { get; set; }
       // public Person Person { get; set; }
        
       // [NotMapped]
      //  public List<Auction> Auctions { get; set; }
    }
}
