using AuctionsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public class ThingRepo : IThingRepo
    {
        private readonly MyDbContext db;

        public ThingRepo(MyDbContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task<FinalThing> GetThingOrNull(int thingID) { 
           var thing = await db.Things.FindAsync(thingID);
            return thing?.GetFinalThing();
        }

        public async Task<IEnumerable<FinalThing>> ListThings(string thingNev = null) => await db.Things.Select(th => th.GetFinalThing()).ToListAsync();
        

        public async Task DeleteThing(int thingID)
        {
            var thing =await db.Things.FindAsync(thingID);
            db.Things.Remove(thing);
            db.SaveChanges();
        }

        public async Task ModifyThing(int thingID, FinalThing modositott)
        {
            Thing thing = await db.Things.FindAsync(thingID);
            thing.Name = modositott.Name;
            thing.Desccription = modositott.Desccription;
            db.SaveChanges();
        }

        public async Task CreateThing(FinalThing uj)
        {
            Thing thing = new Thing();
            thing.Name = uj.Name;
            thing.Desccription = uj.Desccription;
            thing.PersonID = 1;
            db.Things.Add(thing);
            db.SaveChanges();
        }
    }

    internal static class ThingExtensions
    {
        public static FinalThing GetFinalThing(this Thing t)
        {
            return new FinalThing(t.ID, t.Name, t.Desccription);
        }
    }
}
