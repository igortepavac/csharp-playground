using EventXyz.Forms;
using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventXyz.NavigationControllers {
    public class ArtistDetailsNavigationController {

        public void NavigateToArtistEditor(Artist artist = null) {
            new FormArtistEditor(artist).Show();
        }

        public string ShowImportDialog() {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "txt files (*.txt)|*.txt|JSON files (*.json)|*.json|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK) {
                var filePath = dialog.FileName;
                var extension = Path.GetExtension(filePath);
                if (!(extension == ".json") && !(extension == ".txt")) {
                    MessageBox.Show("Datoteka mora biti JSON ili txt!", "Greška!");
                    return null;
                }

                using var fileStream = dialog.OpenFile();
                using StreamReader reader = new StreamReader(fileStream);
                var fileContent = reader.ReadToEnd();
                return fileContent;
            }
            return null;
        }

        public string ShowExportDialog() {
            using SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON file|*.json";
            dialog.Title = "Export artists";
            if (dialog.ShowDialog() == DialogResult.OK) {
                return dialog.FileName;
            }
            return null;
        }

        public void ShowUnknownErrorDialog() {
            MessageBox.Show("Došlo je do neočekivane pogreške.", "Greška!");
        }
    }
}
