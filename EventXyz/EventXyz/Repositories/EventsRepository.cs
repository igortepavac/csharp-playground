using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Repositories {
    public class EventsRepository : BaseEntityRepository<MusicEvent> {

        private List<MusicEvent> events = new List<MusicEvent>() {
            new MusicEvent(1, "Opis 1"),
            new MusicEvent(2, "opis2")
        };

        public override List<MusicEvent> GetItems() {
            return events;
        }

        public override MusicEvent GetItem(int id) {
            return events.Find(e => e.Id == id);
        }

        protected override void AddItemInternal(MusicEvent item) {
            events.Add(item);
        }

        protected override void UpdateItemInternal(MusicEvent item) {
            events = events.Select(e => e.Id == item.Id ? item : e).ToList();
        }

        protected override void DeleteItemInternal(int id) {
            events = events.FindAll(e => !(e.Id == id));
        }
    }
}
