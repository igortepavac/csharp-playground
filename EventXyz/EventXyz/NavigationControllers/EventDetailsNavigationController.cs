using EventXyz.Forms;
using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.NavigationControllers {
    public class EventDetailsNavigationController {

        public void NavigateToEventEditor(MusicEvent musicEvent = null) {
            new FormEventEditor(musicEvent).Show();
        }
    }
}
