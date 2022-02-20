using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Repositories {
    public class ArtistsRepository : BaseEntityRepository<Artist> {

        private List<Artist> artists = new List<Artist>() {
            new Artist(1, "Gnork", "Pop"),
            new Artist(2, "Valentino", "Rock")
        };

        public override List<Artist> GetItems() {
            return artists;
        }

        public override Artist GetItem(int id) {
            return artists.Find(artist => artist.Id == id);
        }

        protected override void AddItemInternal(Artist artist) {
            artists.Add(artist);
        }

        protected override void UpdateItemInternal(Artist artist) {
            artists = artists.Select(a => a.Id == artist.Id ? artist : a).ToList();
        }

        protected override void DeleteItemInternal(int id) {
            artists = artists.FindAll(artist => !(artist.Id == id));
        }
    }
}
