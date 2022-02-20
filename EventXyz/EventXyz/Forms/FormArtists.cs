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
    public partial class FormArtists : Form {
        public FormArtists() {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {
            InitializeButtons();
            InitializeListView();
        }

        private void InitializeButtons() {
            btnAddNewItem.Click += (_, _) => { };
            btnDeleteItem.Click += (_, _) => { };
            btnEditItem.Click += (_, _) => { };

            btnDeleteItem.EnabledChanged += (_, _) => { ControlUtils.UpdateStyle(btnDeleteItem, btnDeleteItem.Enabled); };
            btnEditItem.EnabledChanged += (_, _) => { ControlUtils.UpdateStyle(btnEditItem, btnEditItem.Enabled); };
            btnDeleteItem.Enabled = false;
            btnEditItem.Enabled = false;
        }

        private void InitializeListView() {
            lvItems.SelectedIndexChanged += (_, _) => {
                var hasSelection = lvItems.SelectedItems.Count > 0;
                btnDeleteItem.Enabled = hasSelection;
                btnEditItem.Enabled = hasSelection;

                var selectedItemId = hasSelection ? lvItems.SelectedItems[0].Text : null;
                // TODO: Use selectedItemId
            };
        }
    }
}
