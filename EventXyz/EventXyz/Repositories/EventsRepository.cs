using EventXyz.Models;
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

        private List<MusicEvent> events = new List<MusicEvent>() {
            new MusicEvent(1, "Opis 1", 1000, new Artist(1, "Valentino", "Pop")),
            new MusicEvent(2, "Opis 2", 7000, new Artist(2, "Bonno", "Rock"))
        };

        public override async Task<List<MusicEvent>> GetItemsAsync() {
            return events;
        }

        public override async Task<MusicEvent> GetItemAsync(int id) {
            return events.Find(e => e.Id == id);
        }

        protected override async Task AddItemInternalAsync(MusicEvent item) {
            events.Add(item);
        }

        protected override async Task UpdateItemInternalAsync(MusicEvent item) {
            events = events.Select(e => e.Id == item.Id ? item : e).ToList();
        }

        protected override async Task DeleteItemInternalAsync(int id) {
            events = events.FindAll(e => !(e.Id == id));
        }
    }
}
