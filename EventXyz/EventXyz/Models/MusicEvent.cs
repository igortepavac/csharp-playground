using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Models {
    public class MusicEvent {

        public int Id { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }

        public int ArtistId { get; set; }        
        public Artist Artist { get; set; }
    }
}
