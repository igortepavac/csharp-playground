using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public interface IArtistEditorPresenter {

        public void Initialize(Artist artist);

        public void OnSave(string name, string genre);
    }
}
