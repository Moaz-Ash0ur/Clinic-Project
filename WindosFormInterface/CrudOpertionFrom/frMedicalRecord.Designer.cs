namespace ClinicManagmentSystem
{
    partial class frMedicalRecord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbMedicalRecordID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDecrption = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDigns = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveMedical = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddPrescr = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medical Record ID:";
            // 
            // lbMedicalRecordID
            // 
            this.lbMedicalRecordID.AutoSize = true;
            this.lbMedicalRecordID.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMedicalRecordID.Location = new System.Drawing.Point(251, 30);
            this.lbMedicalRecordID.Name = "lbMedicalRecordID";
            this.lbMedicalRecordID.Size = new System.Drawing.Size(26, 22);
            this.lbMedicalRecordID.TabIndex = 2;
            this.lbMedicalRecordID.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Visit Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Diagnosis:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-2, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "AdditionalNotes :";
            // 
            // txtDecrption
            // 
            this.txtDecrption.BorderRadius = 10;
            this.txtDecrption.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDecrption.DefaultText = "";
            this.txtDecrption.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDecrption.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDecrption.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDecrption.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDecrption.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtDecrption.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDecrption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecrption.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDecrption.Location = new System.Drawing.Point(221, 137);
            this.txtDecrption.Name = "txtDecrption";
            this.txtDecrption.PasswordChar = '\0';
            this.txtDecrption.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtDecrption.PlaceholderText = "";
            this.txtDecrption.SelectedText = "";
            this.txtDecrption.Size = new System.Drawing.Size(229, 41);
            this.txtDecrption.TabIndex = 6;
            // 
            // txtNote
            // 
            this.txtNote.BorderRadius = 10;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.DefaultText = "";
            this.txtNote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNote.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNote.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNote.Location = new System.Drawing.Point(221, 297);
            this.txtNote.Name = "txtNote";
            this.txtNote.PasswordChar = '\0';
            this.txtNote.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtNote.PlaceholderText = "";
            this.txtNote.SelectedText = "";
            this.txtNote.Size = new System.Drawing.Size(229, 41);
            this.txtNote.TabIndex = 7;
            // 
            // txtDigns
            // 
            this.txtDigns.BorderRadius = 10;
            this.txtDigns.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDigns.DefaultText = "";
            this.txtDigns.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDigns.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDigns.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDigns.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDigns.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtDigns.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDigns.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDigns.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDigns.Location = new System.Drawing.Point(221, 216);
            this.txtDigns.Name = "txtDigns";
            this.txtDigns.PasswordChar = '\0';
            this.txtDigns.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtDigns.PlaceholderText = "";
            this.txtDigns.SelectedText = "";
            this.txtDigns.Size = new System.Drawing.Size(229, 41);
            this.txtDigns.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.DarkCyan;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(255, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 33);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseTransparentBackground = true;
            // 
            // btnSaveMedical
            // 
            this.btnSaveMedical.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveMedical.BorderColor = System.Drawing.Color.Transparent;
            this.btnSaveMedical.BorderRadius = 10;
            this.btnSaveMedical.BorderThickness = 1;
            this.btnSaveMedical.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveMedical.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveMedical.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveMedical.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveMedical.FillColor = System.Drawing.Color.DarkCyan;
            this.btnSaveMedical.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMedical.ForeColor = System.Drawing.Color.White;
            this.btnSaveMedical.Location = new System.Drawing.Point(70, 406);
            this.btnSaveMedical.Name = "btnSaveMedical";
            this.btnSaveMedical.Size = new System.Drawing.Size(109, 33);
            this.btnSaveMedical.TabIndex = 10;
            this.btnSaveMedical.Text = "Save";
            this.btnSaveMedical.UseTransparentBackground = true;
            this.btnSaveMedical.Click += new System.EventHandler(this.btnSaveMedical_Click);
            // 
            // btnAddPrescr
            // 
            this.btnAddPrescr.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPrescr.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddPrescr.BorderRadius = 10;
            this.btnAddPrescr.BorderThickness = 1;
            this.btnAddPrescr.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPrescr.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPrescr.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPrescr.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPrescr.Enabled = false;
            this.btnAddPrescr.FillColor = System.Drawing.Color.DarkCyan;
            this.btnAddPrescr.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPrescr.ForeColor = System.Drawing.Color.White;
            this.btnAddPrescr.Location = new System.Drawing.Point(139, 472);
            this.btnAddPrescr.Name = "btnAddPrescr";
            this.btnAddPrescr.Size = new System.Drawing.Size(164, 33);
            this.btnAddPrescr.TabIndex = 11;
            this.btnAddPrescr.Text = "Add Prescription";
            this.btnAddPrescr.UseTransparentBackground = true;
            this.btnAddPrescr.Click += new System.EventHandler(this.btnAddPrescr_Click);
            // 
            // frMedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(483, 537);
            this.Controls.Add(this.btnAddPrescr);
            this.Controls.Add(this.btnSaveMedical);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDigns);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtDecrption);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMedicalRecordID);
            this.Controls.Add(this.label1);
            this.Name = "frMedicalRecord";
            this.Text = "MedicalRecord";
            this.Load += new System.EventHandler(this.frMedicalRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMedicalRecordID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtDecrption;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;
        private Guna.UI2.WinForms.Guna2TextBox txtDigns;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSaveMedical;
        private Guna.UI2.WinForms.Guna2Button btnAddPrescr;
    }
}