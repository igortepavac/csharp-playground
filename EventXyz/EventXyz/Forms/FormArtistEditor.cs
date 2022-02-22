using EventXyz.Models;
using EventXyz.Mvp.Artists.Editor;
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
    public partial class FormArtistEditor : Form, IArtistEditorView {

        private readonly IArtistEditorPresenter presenter;

        public FormArtistEditor() {
            InitializeComponent();
        }

        public FormArtistEditor(Artist artist) {
            presenter = DependencyGraphUtil.GetArtistEditorPresenter(this);
            InitializeComponent();
            presenter.Initialize(artist);
        }

        protected override void OnLoad(EventArgs e) {
            ActiveControl = lblName;
            btnSave.Click += (_, _) => presenter.OnSave(tbName.Text, tbGenre.Text);
        }

        public void ShowId(int id) {
            tbId.Text = id.ToString();
        }

        public void ShowName(string name) {
            tbName.Text = name;
        }

        public void ShowGenre(string genre) {
            tbGenre.Text = genre;
        }

        public void ShowError(string message) {
            MessageBox.Show(message, "Greška!");
        }

        public void CloseForm() {
            Close();
        }
    }
}
