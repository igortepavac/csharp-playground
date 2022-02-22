using EventXyz.Models;
using EventXyz.Mvp.Events.Editor;
using EventXyz.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventXyz.Forms {
    public partial class FormEventEditor : Form, IEventEditorView {

        private readonly IEventEditorPresenter presenter;

        public FormEventEditor() {
            InitializeComponent();
        }

        public FormEventEditor(MusicEvent musicEvent) {
            presenter = DependencyGraphUtil.GetEventEditorPresenter(this);
            InitializeComponent();
            presenter.Initialize(musicEvent);
        }

        protected override void OnLoad(EventArgs e) {
            ActiveControl = rtbDescription;
            btnSave.Click += (_, _) => presenter.OnSave(rtbDescription.Text, tbCapacity.Text, GetSelectedArtistId());
        }

        private int GetSelectedArtistId() {
            int id = -1;
            var selectedItem = cbArtists.SelectedItem;
            if (selectedItem != null) {
                id = ((ArtistPickerItem)selectedItem).Id;
            }
            return id;
        }

        public void ShowId(int id) {
            tbId.Text = id.ToString();
        }

        public void ShowDescription(string description) {
            rtbDescription.Text = description;
        }

        public void ShowCapacity(int capacity) {
            tbCapacity.Text = capacity.ToString();
        }

        public void ShowSelectedArtist(ArtistPickerItem artist) {
            cbArtists.SelectedItem = artist;
        }

        public void FillArtistPicker(List<ArtistPickerItem> artists) {
            artists.ForEach(item => cbArtists.Items.Add(item));
        }

        public void ClearCapacity() {
            tbCapacity.Clear();
        }

        public void ShowError(string message) {
            MessageBox.Show(message, "Greška!");
        }

        public void CloseForm() {
            Close();
        }
    }
}
