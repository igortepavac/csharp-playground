using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public class EventEditorPresenter : IEventEditorPresenter {

        private delegate ArtistPickerItem ArtistMapper(Artist artist);

        private static readonly ArtistMapper artistMapper = artist => new ArtistPickerItem(artist.Id, artist.Name);

        private readonly IEventEditorView view;
        private readonly EventsRepository eventsRepository;
        private readonly ArtistsRepository artistsRepository;

        private int eventId = -1;

        public EventEditorPresenter(IEventEditorView view, EventsRepository eventsRepository, ArtistsRepository artistsRepository) {
            this.view = view;
            this.eventsRepository = eventsRepository;
            this.artistsRepository = artistsRepository;
        }

        public async void Initialize(MusicEvent musicEvent) {
            await FillArtistPicker();
            if (musicEvent != null) {
                eventId = musicEvent.Id;
                FillData(musicEvent);
            }
        }

        private async Task FillArtistPicker() {
            var artists = (await artistsRepository.GetItemsAsync())
                .Select(a => artistMapper.Invoke(a))
                .ToList();
            view.FillArtistPicker(artists);
        }

        private void FillData(MusicEvent musicEvent) {
            view.ShowId(musicEvent.Id);
            view.ShowDescription(musicEvent.Description);
            view.ShowCapacity(musicEvent.Capacity);
            view.ShowSelectedArtist(artistMapper.Invoke(musicEvent.Artist));
        }

        public async void OnSave(string description, string capacity, int artistId) {
            if (String.IsNullOrEmpty(description) || String.IsNullOrEmpty(capacity) || artistId == -1) {
                view.ShowError("Potrebno je popuniti sva polja!");
                return;
            }

            int capacityInt;
            try {
                capacityInt = int.Parse(capacity);
            } catch (Exception) {
                view.ClearCapacity();
                view.ShowError("Kapacitet mora biti cijeli broj!");
                return;
            }

            if (eventId != -1) {
                await eventsRepository.UpdateItemAsync(new MusicEvent { Id = eventId, Description = description, Capacity = capacityInt, ArtistId = artistId });
            } else {
                await eventsRepository.AddItemAsync(new MusicEvent { Description = description, Capacity = capacityInt, ArtistId = artistId });
            }
            
            view.CloseForm();
        }
    }
}
