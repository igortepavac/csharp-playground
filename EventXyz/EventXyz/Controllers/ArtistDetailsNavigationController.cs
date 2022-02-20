using EventXyz.Forms;
using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Controllers {
    public class ArtistDetailsNavigationController {

        public void NavigateToArtistEditor(Artist artist = null) {
            new FormArtistEditor(artist).Show();
        }
    }
}
