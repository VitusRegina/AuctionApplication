using AuctionsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public interface IThingRepo
    {
        public Task<IEnumerable<FinalThing>> ListThings(string thingNev = null);
        public Task<FinalThing> GetThingOrNull(int thingID);
        public Task DeleteThing(int thingID);
        public Task ModifyThing(int thingID, FinalThing modositott);

        public Task CreateThing(FinalThing modositott);
    }
}
