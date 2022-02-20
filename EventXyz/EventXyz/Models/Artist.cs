﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Models {
    public class Artist {
        public Artist(int id, string name, string genre) {
            Id = id;
            Name = name;
            Genre = genre;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
    }
}
