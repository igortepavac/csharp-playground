using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventXyz.Utils {
    public static class ControlUtils {

        public static void UpdateStyle(Control control, bool enabled) {
            control.BackColor = enabled ? Color.FromArgb(26, 29, 31) : Color.FromArgb(47, 53, 56);
        }
    }
}
