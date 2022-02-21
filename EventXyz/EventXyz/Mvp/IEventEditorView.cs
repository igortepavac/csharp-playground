using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public interface IEventEditorView {

        public void ShowId(int id);
        public void ShowDescription(string description);
        public void ShowCapacity(int capacity);
        public void ShowSelectedArtist(ArtistPickerItem artist);

        public void FillArtistPicker(List<ArtistPickerItem> artists);

        public void ClearCapacity();

        public void ShowError(string message);

        public void CloseForm();
    }
}
