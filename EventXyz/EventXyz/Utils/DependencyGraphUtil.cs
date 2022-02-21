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
            return new ArtistsDetailsPresenter(view, ArtistsRepository.Instance, new ArtistDetailsNavigationController());
        }

        public static IEntityDetailsPresenter GetEventDetailsPresenter(IEntityDetailsView view) {
            return new EventsDetailsPresenter(view, EventsRepository.Instance, new EventDetailsNavigationController());
        }

        public static IArtistEditorPresenter GetArtistEditorPresenter(IArtistEditorView view) {
            return new ArtistEditorPresenter(view, ArtistsRepository.Instance);
        }

        public static IEventEditorPresenter GetEventEditorPresenter(IEventEditorView view) {
            return new EventEditorPresenter(view, EventsRepository.Instance, ArtistsRepository.Instance);
        }
    }
}
