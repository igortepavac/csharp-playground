using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public class EventEditorPresenter : IEventEditorPresenter {

        private readonly IEventEditorView view;
        private readonly EventsRepository eventsRepository;
        private readonly ArtistsRepository artistsRepository;

        private int eventId = -1;

        public EventEditorPresenter(IEventEditorView view, EventsRepository eventsRepository, ArtistsRepository artistsRepository) {
            this.view = view;
            this.eventsRepository = eventsRepository;
            this.artistsRepository = artistsRepository;
        }

        public void Initialize(MusicEvent musicEvent) {
            FillArtistPicker();
            if (musicEvent != null) {
                eventId = musicEvent.Id;
                FillData(musicEvent);
            }
        }

        private async void FillArtistPicker() {
            var artists = (await artistsRepository.GetItemsAsync())
                .Select(a => new ArtistPickerItem(a.Id, a.Name))
                .ToList();
            view.FillArtistPicker(artists);
        }

        private void FillData(MusicEvent musicEvent) {
            view.ShowId(musicEvent.Id);
            view.ShowDescription(musicEvent.Description);
            view.ShowCapacity(1);
            view.ShowSelectedArtist(new ArtistPickerItem(1, "The One"));
        }

        public async void OnSave(string description, string capacity, int artistId) {
            if (String.IsNullOrEmpty(description) || String.IsNullOrEmpty(capacity) || artistId == -1) {
                view.ShowError("Potrebno je popuniti sva polja!");
                return;
            }
            int capacityInt = 0;
            try {
                capacityInt = int.Parse(capacity);
            } catch (Exception) {
                view.ClearCapacity();
                view.ShowError("Kapacitet mora biti cijeli broj!");
                return;
            }

            if (eventId != -1) {
                await eventsRepository.UpdateItemAsync(new MusicEvent(eventId, description));
            } else {
                await eventsRepository.AddItemAsync(new MusicEvent(0, description));
            }
            view.CloseForm();
        }
    }
}
