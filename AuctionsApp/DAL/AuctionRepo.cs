using AuctionsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public class AuctionRepo : IAuctionRepo
    {
        private readonly MyDbContext db;

        public AuctionRepo(MyDbContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task<FinalAuction> GetAuctionOrNull(int aucID)
        {
            var auc = await db.Auctions.FindAsync(aucID);
            Thing thing =  db.Things.Where(t => t.ID == auc.ThingID).FirstOrDefault();
            int b = db.Bids.Max(b => b.Sum);
            return auc?.GetFinalAuction(thing,b);
        }

        public async Task<IEnumerable<FinalAuction>> ListAuctions()
        {
            var list = await db.Auctions.ToListAsync();
            List<FinalAuction> finallist=new List<FinalAuction>();
            foreach(var auc in list)
            {
                Thing thing = db.Things.Where(t => t.ID == auc.ThingID).FirstOrDefault();
                int b = db.Bids.Max(b => b.Sum);
                finallist.Add(auc?.GetFinalAuction(thing, b));
            }
            return finallist;
        }


        public async Task DeleteAuction(int aucID)
        {
            var auc = await db.Auctions.FindAsync(aucID);
            db.Auctions.Remove(auc);
            db.SaveChanges();
        }

        public async Task ModifyAuction(int aucID, FinalAuction modositott)
        {
            Auction auc = await db.Auctions.FindAsync(aucID);
            auc.Startprice = modositott.Startprice;
            auc.ThingID = modositott.ThingID;
            db.SaveChanges();
        }

        public async Task CreateAuction(FinalAuction uj)
        {
            Auction auc = new Auction();
            auc.Startprice = uj.Startprice;
            auc.ThingID = uj.ThingID;
            db.Auctions.Add(auc);
            db.SaveChanges();
        }
    }

    internal static class AuctionExtensions
    {
        public static FinalAuction GetFinalAuction(this Auction a, Thing thing, int b)
        { 
            return new FinalAuction(a.ID, a.Startprice, a.ThingID, thing.Name, thing.Desccription,b);
        }
    }
}
