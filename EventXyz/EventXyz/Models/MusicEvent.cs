using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Models {
    public class MusicEvent {
        public MusicEvent(int id, string description, int capacity, Artist artist) {
            Id = id;
            Description = description;
            Capacity = capacity;
            ArtistId = artist.Id;
            Artist = artist;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
