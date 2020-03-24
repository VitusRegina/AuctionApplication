using AuctionsApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.BL
{
    public class BidManager
    {
        private readonly IBidRepo bidRepo;
        public BidManager(IBidRepo br)
        {
            bidRepo = br;
        }
        public async Task<IEnumerable<FinalBid>> ListBids(string nev = null) => await bidRepo.ListBids(nev);

        public async Task<FinalBid> getBidOrNull(int bidID) => await bidRepo.GetBidOrNull(bidID);

        public async Task<bool> TryTorolBid(int bidID)
        {
            await bidRepo.DeleteBid(bidID);
            return true;
        }

        public async Task modifyBid(int bidID, FinalBid modositott) => await bidRepo.ModifyBid(bidID, modositott);

        public async Task createBid(FinalBid uj) => await bidRepo.CreateBid(uj);
    }
}
