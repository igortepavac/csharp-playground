using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp.Events.Editor {
    public interface IEventEditorPresenter {

        public void Initialize(MusicEvent musicEvent);

        public void OnSave(string description, string capacity, int artistId);
    }
}
