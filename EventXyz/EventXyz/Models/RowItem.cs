using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Models {
    public class RowItem {
        public RowItem(int id, List<string> columns) {
            Id = id;
            Columns = columns;
        }

        public int Id { get; set; }

        public List<string> Columns { get; set; }
    }
}
