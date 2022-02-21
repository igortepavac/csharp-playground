using EventXyz.Data;
using EventXyz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Repositories {
    public class ArtistsRepository : BaseEntityRepository<Artist> {

        private static ArtistsRepository instance = null;
        private static readonly object instanceLock = new object();

        private ArtistsRepository() { }

        public static ArtistsRepository Instance {
            get {
                if (instance == null) {
                    lock (instanceLock) {
                        if (instance == null) {
                            instance = new ArtistsRepository();
                        }
                    }
                }
                return instance;
            }
        }

        public override async Task<List<Artist>> GetItemsAsync() {
            using var context = new EventsDbContext();
            return await context.Artists.ToListAsync();
        }

        public override async Task<Artist> GetItemAsync(int id) {
            using var context = new EventsDbContext();
            return await context.Artists.Where(artist => artist.Id == id).FirstAsync();
        }

        protected override async Task AddItemInternalAsync(Artist item) {
            using var context = new EventsDbContext();
            await context.Artists.AddAsync(item);
            await context.SaveChangesAsync();
        }

        protected override async Task UpdateItemInternalAsync(Artist item) {
            using var context = new EventsDbContext();
            var currentItem = await context.Artists.Where(artist => artist.Id == item.Id).FirstAsync();
            context.Entry(currentItem).CurrentValues.SetValues(item);
            await context.SaveChangesAsync();
        }

        protected override async Task DeleteItemInternalAsync(int id) {
            using var context = new EventsDbContext();
            var item = new Artist() { Id = id };
            context.Artists.Attach(item);
            context.Artists.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
