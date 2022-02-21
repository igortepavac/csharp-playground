using EventXyz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Data {
    public class EventsDbContext : DbContext {

        // An empty contructor is needed for Migration tools
        public EventsDbContext() : base() { }

        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) { }

        public DbSet<MusicEvent> MusicEvents { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(Data.Database.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
