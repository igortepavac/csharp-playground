﻿using EventXyz.Models;
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
    public partial class FormArtistEditor : Form {

        public FormArtistEditor() {
            InitializeComponent();
        }

        public FormArtistEditor(Artist artist) {
            InitializeComponent();
            label1.Text = artist != null ? artist.Name : "Nema";
        }
    }
}
