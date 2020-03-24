using AuctionsApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.BL
{
    public class AuctionManager
    {
        private readonly IAuctionRepo aucRepo;
        public AuctionManager(IAuctionRepo ar)
        {
            aucRepo = ar;
        }
        public async Task<IEnumerable<FinalAuction>> ListAuctions() => await aucRepo.ListAuctions();

        public async Task<FinalAuction> getAuctionOrNull(int auctionID) => await aucRepo.GetAuctionOrNull(auctionID);

        public async Task<bool> TryTorolAuction(int auctionID)
        {
            await aucRepo.DeleteAuction(auctionID);
            return true;
        }

        public async Task modifyAuction(int auctionID, FinalAuction modositott) => await aucRepo.ModifyAuction(auctionID, modositott);

        public async Task createAuction(FinalAuction uj) => await aucRepo.CreateAuction(uj);
    }
}
