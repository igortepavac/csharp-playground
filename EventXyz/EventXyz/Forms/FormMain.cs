using EventXyz.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventXyz {
    public partial class FormMain : Form {

        private readonly MainNavigationController navigationController;

        public FormMain() {
            InitializeComponent();
            
            navigationController = new MainNavigationController(
                new Dictionary<MainNavigationController.NavigationItem, Control> {
                    { MainNavigationController.NavigationItem.Artists, btnArtists }
                },
                panelFormContainer,
                lblTitle
            );

            // Navigate to initial form
            navigationController.NavigateTo(MainNavigationController.NavigationItem.Artists);
        }
    }
}
