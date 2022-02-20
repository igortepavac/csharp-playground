using EventXyz.Models;
using EventXyz.Mvp;
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
    public partial class FormEntityDetails : Form, IEntityDetailsView {

        public delegate IEntityDetailsPresenter PresenterFactory(IEntityDetailsView view);

        private readonly IEntityDetailsPresenter presenter;

        public FormEntityDetails(PresenterFactory presenterFactory) {
            this.presenter = presenterFactory.Invoke(this);
            InitializeComponent();
        }

        public FormEntityDetails() {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {
            InitializeButtons();
            InitializeListView();
            presenter.Initialize();
        }

        private void InitializeButtons() {
            btnAddNewItem.Click += (_, _) => { presenter.OnAddNewItem(); };
            btnDeleteItem.Click += (_, _) => { OnDeleteItem(); };
            btnEditItem.Click += (_, _) => { presenter.OnEditItem(GetSelectedItemId()); };

            btnDeleteItem.EnabledChanged += (_, _) => { UpdateActionButtonStyle(btnDeleteItem, btnDeleteItem.Enabled); };
            btnEditItem.EnabledChanged += (_, _) => { UpdateActionButtonStyle(btnEditItem, btnEditItem.Enabled); };
            btnDeleteItem.Enabled = false;
            btnEditItem.Enabled = false;
        }

        private void InitializeListView() {
            lvItems.SelectedIndexChanged += (_, _) => {
                var hasSelection = lvItems.SelectedItems.Count > 0;
                btnDeleteItem.Enabled = hasSelection;
                btnEditItem.Enabled = hasSelection;
            };
        }

        private int GetSelectedItemId() {
            int.TryParse(lvItems.SelectedItems[0].Text, out int id);
            return id;
        }

        private void OnDeleteItem() {
            if (MessageBox.Show("Jeste li sigurni da želite obrisati označeni red?", "Oprez!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                presenter.OnDeleteItem(GetSelectedItemId());
            }
        }

        public void ShowHeaders(List<HeaderItem> headers) {
            headers.ForEach((header) => {
                lvItems.Columns.Add(new ColumnHeader {
                    Text = header.Text,
                    TextAlign = HorizontalAlignment.Center,
                    Width = header.Width
                });
            });
        }

        public void ShowRows(List<RowItem> rows) {
            rows.ForEach((row) => {
                var item = new ListViewItem {
                    Text = row.Id.ToString()
                };
                row.Columns.ForEach((column) => {
                    item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = column });
                });
                lvItems.Items.Add(item);
            });
        }

        private static void UpdateActionButtonStyle(Control control, bool enabled) {
            control.BackColor = enabled ? Color.FromArgb(26, 29, 31) : Color.FromArgb(47, 53, 56);
        }
    }
}
