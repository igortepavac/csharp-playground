
namespace EventXyz.Forms {
    partial class FormEventEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnSave = new System.Windows.Forms.Button();
            this.tbCapacity = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblArtist = new System.Windows.Forms.Label();
            this.cbArtists = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(111, 569);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(303, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Spremi";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tbCapacity
            // 
            this.tbCapacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbCapacity.BackColor = System.Drawing.SystemColors.Window;
            this.tbCapacity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCapacity.Location = new System.Drawing.Point(111, 339);
            this.tbCapacity.Name = "tbCapacity";
            this.tbCapacity.PlaceholderText = "Unesi kapacitet događaja ovdje";
            this.tbCapacity.Size = new System.Drawing.Size(303, 29);
            this.tbCapacity.TabIndex = 2;
            this.tbCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCapacity
            // 
            this.lblCapacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCapacity.Location = new System.Drawing.Point(211, 300);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(94, 25);
            this.lblCapacity.TabIndex = 11;
            this.lblCapacity.Text = "Kapacitet";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(233, 128);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(51, 25);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Opis";
            // 
            // tbId
            // 
            this.tbId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbId.BackColor = System.Drawing.SystemColors.Window;
            this.tbId.Enabled = false;
            this.tbId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbId.Location = new System.Drawing.Point(111, 69);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(303, 29);
            this.tbId.TabIndex = 8;
            this.tbId.Text = "ID se generira automatski";
            this.tbId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(243, 30);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(32, 25);
            this.lblId.TabIndex = 7;
            this.lblId.Text = "ID";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(111, 171);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(303, 96);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = "";
            // 
            // lblArtist
            // 
            this.lblArtist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblArtist.Location = new System.Drawing.Point(215, 407);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(80, 25);
            this.lblArtist.TabIndex = 15;
            this.lblArtist.Text = "Izvođač";
            // 
            // cbArtists
            // 
            this.cbArtists.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbArtists.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbArtists.FormattingEnabled = true;
            this.cbArtists.Location = new System.Drawing.Point(111, 447);
            this.cbArtists.Name = "cbArtists";
            this.cbArtists.Size = new System.Drawing.Size(303, 29);
            this.cbArtists.TabIndex = 3;
            // 
            // FormEventEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 640);
            this.Controls.Add(this.cbArtists);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbCapacity);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lblId);
            this.Name = "FormEventEditor";
            this.Text = "Uređivanje događaja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.ComboBox cbArtists;
    }
}