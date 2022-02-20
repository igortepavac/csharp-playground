using EventXyz.Controllers;
using EventXyz.Mvp;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Utils {
    public static class DependencyGraphUtil {

        public static IEntityDetailsPresenter GetArtistDetailsPresenter(IEntityDetailsView view) {
            return new ArtistsDetailsPresenter(view, new ArtistsRepository(), new ArtistDetailsNavigationController());
        }

        public static IEntityDetailsPresenter GetEventDetailsPresenter(IEntityDetailsView view) {
            return new EventsDetailsPresenter(view, new EventsRepository(), new EventDetailsNavigationController());
        }
    }
}
