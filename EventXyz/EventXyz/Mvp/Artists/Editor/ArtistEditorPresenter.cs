using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp.Artists.Editor {
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

        public async void OnSave(string name, string genre) {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(genre)) {
                view.ShowError("Potrebno je popuniti sva polja!");
            } else {
                if (artistId != -1) {
                    await repository.UpdateItemAsync(new Artist { Id = artistId, Name = name, Genre = genre });
                } else {
                    await repository .AddItemAsync(new Artist { Name = name, Genre = genre });
                }
                view.CloseForm();
            }
        }
    }
}
