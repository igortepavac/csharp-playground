using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public class ArtistEditorPresenter : IArtistEditorPresenter {

        private readonly IArtistEditorView view;
        private readonly ArtistsRepository repository;

        private int artistId = -1;

        public ArtistEditorPresenter(IArtistEditorView view, ArtistsRepository repository) {
            this.view = view;
            this.repository = repository;
        }

        public void Initialize(Artist artist) {
            if (artist != null) {
                artistId = artist.Id;
                ShowArtistData(artist);
            }
        }

        private void ShowArtistData(Artist artist) {
            view.ShowId(artist.Id);
            view.ShowName(artist.Name);
            view.ShowGenre(artist.Genre);
        }

        public void OnSave(string name, string genre) {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(genre)) {
                view.ShowError("Potrebno je popuniti sva polja!");
            } else {
                if (artistId != -1) {
                    repository.UpdateItem(new Artist(artistId, name, genre));
                } else {
                    repository.AddItem(new Artist(name, genre));
                }
                view.CloseForm();
            }
        }
    }
}
