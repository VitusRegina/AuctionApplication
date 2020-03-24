using AuctionsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public class BidRepo : IBidRepo
    {
        private readonly MyDbContext db;

        public BidRepo(MyDbContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task<FinalBid> GetBidOrNull(int thingID)
        {
            var thing = await db.Bids.FindAsync(thingID);
            return thing?.GetFinalBid();
        }

        public async Task<IEnumerable<FinalBid>> ListBids(string bidNev = null) => await db.Bids.Select(b => b.GetFinalBid()).ToListAsync();


        public async Task DeleteBid(int bidID)
        {
            var bid = await db.Bids.FindAsync(bidID);
            db.Bids.Remove(bid);
            db.SaveChanges();
        }

        public async Task ModifyBid(int bidID, FinalBid modositott)
        {
            Bid bid = await db.Bids.FindAsync(bidID);
            bid.Sum = modositott.Sum;
            db.SaveChanges();
        }

        public async Task CreateBid(FinalBid uj)
        {
            Bid bid = new Bid();
            bid.Sum = uj.Sum;
            bid.AuctionID = 1;
            db.Bids.Add(bid);
            db.SaveChanges();
        }
    }

    internal static class BidExtensions
    {
        public static FinalBid GetFinalBid(this Bid b)
        {
            return new FinalBid(b.ID, b.Sum);
        }
    }
}
