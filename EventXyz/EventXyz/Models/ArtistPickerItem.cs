using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Models {
    public class ArtistPickerItem {
        public ArtistPickerItem(int id, string name) {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public override string ToString() {
            return Name;
        }

        public override bool Equals(object obj) {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            } else {
                return ((ArtistPickerItem)obj).Id == this.Id;
            }
        }

        public override int GetHashCode() {
            return Id;
        }
    }
}
