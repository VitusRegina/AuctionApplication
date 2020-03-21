using AuctionsApp.DAL;
using AuctionsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.BL
{
    public class ThingManager
    {
        private readonly IThingRepo thingRepo;
        public ThingManager(IThingRepo tr)
        {
            thingRepo = tr;
        }
        public async Task<IEnumerable<FinalThing>> ListThings(string nev = null) => await thingRepo.ListThings(nev);

        public async Task<FinalThing> getThingOrNull(int thingID) => await thingRepo.GetThingOrNull(thingID);

        public async Task<bool> TryTorolThing(int thingID)
        {
            await thingRepo.DeleteThing(thingID);
            return true;
        }

        public async Task modifyThing(int thingID, FinalThing modositott) => await thingRepo.ModifyThing(thingID, modositott);

        public async Task createThing(FinalThing uj) => await thingRepo.CreateThing(uj);
    }
}
