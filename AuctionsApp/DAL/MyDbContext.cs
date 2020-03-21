using AuctionsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Bid> Bids { get; set; }

        public DbSet<Auction> Auctions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Thing>().ToTable("Objects");
            modelBuilder.Entity<Bid>().ToTable("Bids");
            modelBuilder.Entity<Auction>().ToTable("Auctions");
        }
    }
}
