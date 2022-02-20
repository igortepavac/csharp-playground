using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Models {
    public struct HeaderItem {
        public HeaderItem(string text, int width) {
            Text = text;
            Width = width;
        }

        public string Text { get; private set; }
        public int Width{ get; private set; }
    }
}
