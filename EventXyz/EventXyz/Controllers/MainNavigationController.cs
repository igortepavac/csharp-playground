using EventXyz.Forms;
using EventXyz.Mvp;
using EventXyz.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventXyz.Controllers {

    public static class Extensions {

        public static Form GetForm(this MainNavigationController.NavigationItem item) {
            return item switch {
                MainNavigationController.NavigationItem.Artists => new FormEntityDetails((view) => { return DependencyGraphUtil.GetArtistDetailsPresenter(view); }),
                _ => throw new Exception(String.Format("Unhandled navigation item - {0}", item)),
            };
        }

        public static string GetTitle(this MainNavigationController.NavigationItem item) {
            return item switch {
                MainNavigationController.NavigationItem.Artists => "Izvođači",
                _ => throw new Exception(String.Format("Unhandled navigation item - {0}", item)),
            };
        }
    }

    public class MainNavigationController {

        public enum NavigationItem {
            Artists
        }

        private readonly Dictionary<NavigationItem, Control> navigationControls;
        private readonly Panel panelFormContainer;
        private readonly Label labelTitle;

        private Form currentForm;

        public MainNavigationController(Dictionary<NavigationItem, Control> navigationControls, Panel panelFormContainer, Label labelTitle) {
            this.navigationControls = navigationControls;
            this.panelFormContainer = panelFormContainer;
            this.labelTitle = labelTitle;
            InitClickListeners();
        }

        private void InitClickListeners() {
            foreach (var control in navigationControls) {
                control.Value.Click += (_, _) => NavigateTo(control.Key);
            }
        }

        public void NavigateTo(MainNavigationController.NavigationItem item) {
            if (currentForm != null) {
                currentForm.Close();
            }
            
            UpdateNavigationControls(item);
            labelTitle.Text = item.GetTitle();

            var itemForm = ConfigureFormStyle(item.GetForm());
            currentForm = itemForm;
            panelFormContainer.Controls.Add(itemForm);
            panelFormContainer.Tag = itemForm;
            itemForm.BringToFront();
            itemForm.Show();
        }

        private void UpdateNavigationControls(NavigationItem selectedItem) {
            foreach (var controlPair in navigationControls) {
                var control = controlPair.Value;
                if (controlPair.Key == selectedItem) {
                    control.BackColor = Color.FromArgb(45, 27, 49);
                } else {
                    control.BackColor = Color.FromArgb(225, 226, 226);
                }
            }
        }

        private Form ConfigureFormStyle(Form form) {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            return form;
        }
    }
}
