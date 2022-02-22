using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp.Artists.Editor {
    public interface IArtistEditorView {

        public void ShowId(int id);
        public void ShowName(string name);
        public void ShowGenre(string genre);

        public void ShowError(string message);

        public void CloseForm();
    }
}
