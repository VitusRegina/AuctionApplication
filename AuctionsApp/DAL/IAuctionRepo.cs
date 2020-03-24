using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public interface IAuctionRepo
    {
        public Task<IEnumerable<FinalAuction>> ListAuctions();
        public Task<FinalAuction> GetAuctionOrNull(int auctionID);
        public Task DeleteAuction(int auctionID);
        public Task ModifyAuction(int auctionID, FinalAuction modositott);

        public Task CreateAuction(FinalAuction uj);
    }
}
