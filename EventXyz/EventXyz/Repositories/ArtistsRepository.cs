using EventXyz.Models;
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

        private List<Artist> artists = new List<Artist>() {
            new Artist(1, "Valentino", "Pop"),
            new Artist(2, "Bonno", "Rock")
        };

        public override async Task<List<Artist>> GetItemsAsync() {
            return artists;
        }

        public override async Task<Artist> GetItemAsync(int id) {
            return artists.Find(artist => artist.Id == id);
        }

        protected override async Task AddItemInternalAsync(Artist item) {
            artists.Add(item);
        }

        protected override async Task UpdateItemInternalAsync(Artist item) {
            artists = artists.Select(a => a.Id == item.Id ? item : a).ToList();
        }

        protected override async Task DeleteItemInternalAsync(int id) {
            artists = artists.FindAll(artist => !(artist.Id == id));
        }
    }
}
