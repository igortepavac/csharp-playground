using EventXyz.Forms;
using EventXyz.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventXyz.NavigationControllers {

    public static class Extensions {

        public static Form GetForm(this MainNavigationController.NavigationItem item) {
            return item switch {
                MainNavigationController.NavigationItem.Artists => new FormEntityDetails((view) => { return DependencyGraphUtil.GetArtistDetailsPresenter(view); }, importAvailable: true),
                MainNavigationController.NavigationItem.Events => new FormEntityDetails((view) => { return DependencyGraphUtil.GetEventDetailsPresenter(view); }),
                _ => throw new NavigationItemNotFoundException(String.Format("Unhandled navigation item - {0}", item)),
            };
        }

        public static string GetTitle(this MainNavigationController.NavigationItem item) {
            return item switch {
                MainNavigationController.NavigationItem.Artists => "Izvođači",
                MainNavigationController.NavigationItem.Events => "Događaji",
                _ => throw new NavigationItemNotFoundException(String.Format("Unhandled navigation item - {0}", item)),
            };
        }
    }

    public class NavigationItemNotFoundException : Exception {

        public NavigationItemNotFoundException() { }

        public NavigationItemNotFoundException(string message) : base(message) { }
    }

    public class MainNavigationController {

        public enum NavigationItem {
            Artists,
            Events
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

            Form itemForm;
            try {
                labelTitle.Text = item.GetTitle();
                itemForm = ConfigureFormStyle(item.GetForm());
            } catch(NavigationItemNotFoundException e) {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return;
            }

            UpdateNavigationControls(item);
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
                    control.BackColor = Color.FromArgb(26, 29, 31);
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
