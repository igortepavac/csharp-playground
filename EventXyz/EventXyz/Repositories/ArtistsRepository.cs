using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Repositories {
    public class ArtistsRepository {

        public List<Artist> GetItems() {
            var list = new List<Artist>();
            list.Add(new Artist(1, "Gnork", "Pop"));
            list.Add(new Artist(2, "Valentino", "Rock"));
            return list;
        }
    }
}
