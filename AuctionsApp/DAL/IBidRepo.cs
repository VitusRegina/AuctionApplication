using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public interface IBidRepo
    {
        public Task<IEnumerable<FinalBid>> ListBids(string bidNev = null);
        public Task<FinalBid> GetBidOrNull(int bidID);

        public Task<IEnumerable<FinalBid>> SelectBid(int aucID);
        public Task DeleteBid(int bidID);
        public Task ModifyBid(int bidID, FinalBid modositott);
        public Task CreateBid(FinalBid uj);
    }
}
