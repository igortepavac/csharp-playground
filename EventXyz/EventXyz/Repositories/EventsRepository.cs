using EventXyz.Data;
using EventXyz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Repositories {
    public class EventsRepository : BaseEntityRepository<MusicEvent> {

        private static EventsRepository instance = null;
        private static readonly object instanceLock = new object();

        private EventsRepository() { }

        public static EventsRepository Instance {
            get {
                if (instance == null) {
                    lock (instanceLock) {
                        if (instance == null) {
                            instance = new EventsRepository();
                        }
                    }
                }
                return instance;
            }
        }

        public override async Task<List<MusicEvent>> GetItemsAsync() {
            using var context = new EventsDbContext();
            return await context.MusicEvents.Include(e => e.Artist).ToListAsync();
        }

        public override async Task<MusicEvent> GetItemAsync(int id) {
            using var context = new EventsDbContext();
            return await context.MusicEvents.Where(e => e.Id == id).Include(e => e.Artist).FirstAsync();
        }

        protected override async Task AddItemInternalAsync(MusicEvent item) {
            using var context = new EventsDbContext();
            await context.MusicEvents.AddAsync(item);
            await context.SaveChangesAsync();
        }

        protected override async Task UpdateItemInternalAsync(MusicEvent item) {
            using var context = new EventsDbContext();
            var currentItem = await context.MusicEvents.Where(e => e.Id == item.Id).FirstAsync();
            context.Entry(currentItem).CurrentValues.SetValues(item);
            await context.SaveChangesAsync();
        }

        protected override async Task DeleteItemInternalAsync(int id) {
            using var context = new EventsDbContext();
            var item = new MusicEvent() { Id = id };
            context.MusicEvents.Attach(item);
            context.MusicEvents.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
