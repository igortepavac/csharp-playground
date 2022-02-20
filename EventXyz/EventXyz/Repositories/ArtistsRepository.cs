﻿using EventXyz.Models;
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
            new Artist(1, "Gnork", "Pop"),
            new Artist(2, "Valentino", "Rock")
        };

        public override List<Artist> GetItems() {
            return artists;
        }

        public override Artist GetItem(int id) {
            return artists.Find(artist => artist.Id == id);
        }

        protected override void AddItemInternal(Artist item) {
            artists.Add(item);
        }

        protected override void UpdateItemInternal(Artist item) {
            artists = artists.Select(a => a.Id == item.Id ? item : a).ToList();
        }

        protected override void DeleteItemInternal(int id) {
            artists = artists.FindAll(artist => !(artist.Id == id));
        }
    }
}
