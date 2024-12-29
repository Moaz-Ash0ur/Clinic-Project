namespace ClinicManagmentSystem
{
    partial class FrPrescription
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
            this.txtStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavePrescrption = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.txtFrequency = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMedcationName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPrescriptionid = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDosage = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbMedicalRecordID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStartDate
            // 
            this.txtStartDate.BorderRadius = 10;
            this.txtStartDate.Checked = true;
            this.txtStartDate.FillColor = System.Drawing.Color.White;
            this.txtStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.txtStartDate.Location = new System.Drawing.Point(229, 353);
            this.txtStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(229, 35);
            this.txtStartDate.TabIndex = 35;
            this.txtStartDate.Value = new System.DateTime(2024, 12, 11, 19, 48, 47, 754);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 34;
            this.label1.Text = "SpecialInstructions:";
            // 
            // btnSavePrescrption
            // 
            this.btnSavePrescrption.BackColor = System.Drawing.Color.Transparent;
            this.btnSavePrescrption.BorderColor = System.Drawing.Color.Transparent;
            this.btnSavePrescrption.BorderRadius = 10;
            this.btnSavePrescrption.BorderThickness = 1;
            this.btnSavePrescrption.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSavePrescrption.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSavePrescrption.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSavePrescrption.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSavePrescrption.FillColor = System.Drawing.Color.DarkCyan;
            this.btnSavePrescrption.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrescrption.ForeColor = System.Drawing.Color.White;
            this.btnSavePrescrption.Location = new System.Drawing.Point(92, 544);
            this.btnSavePrescrption.Name = "btnSavePrescrption";
            this.btnSavePrescrption.Size = new System.Drawing.Size(109, 33);
            this.btnSavePrescrption.TabIndex = 33;
            this.btnSavePrescrption.Text = "Save";
            this.btnSavePrescrption.UseTransparentBackground = true;
            this.btnSavePrescrption.Click += new System.EventHandler(this.btnSavePayment_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(269, 544);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 33);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseTransparentBackground = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFrequency
            // 
            this.txtFrequency.BorderRadius = 10;
            this.txtFrequency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFrequency.DefaultText = "";
            this.txtFrequency.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFrequency.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFrequency.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFrequency.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFrequency.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtFrequency.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFrequency.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrequency.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFrequency.Location = new System.Drawing.Point(229, 281);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.PasswordChar = '\0';
            this.txtFrequency.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtFrequency.PlaceholderText = "";
            this.txtFrequency.SelectedText = "";
            this.txtFrequency.Size = new System.Drawing.Size(229, 35);
            this.txtFrequency.TabIndex = 31;
            // 
            // txtMedcationName
            // 
            this.txtMedcationName.BorderRadius = 10;
            this.txtMedcationName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedcationName.DefaultText = "";
            this.txtMedcationName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMedcationName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMedcationName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMedcationName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMedcationName.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtMedcationName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMedcationName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedcationName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMedcationName.Location = new System.Drawing.Point(229, 157);
            this.txtMedcationName.Name = "txtMedcationName";
            this.txtMedcationName.PasswordChar = '\0';
            this.txtMedcationName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMedcationName.PlaceholderText = "";
            this.txtMedcationName.SelectedText = "";
            this.txtMedcationName.Size = new System.Drawing.Size(229, 34);
            this.txtMedcationName.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 25);
            this.label4.TabIndex = 29;
            this.label4.Text = "Frequency:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "Dosage:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Medcation Name:";
            // 
            // lbPrescriptionid
            // 
            this.lbPrescriptionid.AutoSize = true;
            this.lbPrescriptionid.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrescriptionid.Location = new System.Drawing.Point(225, 30);
            this.lbPrescriptionid.Name = "lbPrescriptionid";
            this.lbPrescriptionid.Size = new System.Drawing.Size(26, 22);
            this.lbPrescriptionid.TabIndex = 26;
            this.lbPrescriptionid.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 26);
            this.label5.TabIndex = 25;
            this.label5.Text = "Prescription ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 25);
            this.label6.TabIndex = 37;
            this.label6.Text = "Medical Record ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 25);
            this.label7.TabIndex = 38;
            this.label7.Text = "Start Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 418);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 25);
            this.label8.TabIndex = 39;
            this.label8.Text = "End Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.BorderRadius = 10;
            this.txtEndDate.Checked = true;
            this.txtEndDate.FillColor = System.Drawing.Color.White;
            this.txtEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.txtEndDate.Location = new System.Drawing.Point(231, 418);
            this.txtEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(229, 33);
            this.txtEndDate.TabIndex = 40;
            this.txtEndDate.Value = new System.DateTime(2024, 12, 11, 19, 48, 47, 754);
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
            this.txtNote.Location = new System.Drawing.Point(229, 475);
            this.txtNote.Name = "txtNote";
            this.txtNote.PasswordChar = '\0';
            this.txtNote.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtNote.PlaceholderText = "";
            this.txtNote.SelectedText = "";
            this.txtNote.Size = new System.Drawing.Size(229, 50);
            this.txtNote.TabIndex = 41;
            // 
            // txtDosage
            // 
            this.txtDosage.BorderRadius = 10;
            this.txtDosage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDosage.DefaultText = "";
            this.txtDosage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDosage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDosage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDosage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDosage.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtDosage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDosage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDosage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDosage.Location = new System.Drawing.Point(229, 222);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.PasswordChar = '\0';
            this.txtDosage.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtDosage.PlaceholderText = "";
            this.txtDosage.SelectedText = "";
            this.txtDosage.Size = new System.Drawing.Size(229, 33);
            this.txtDosage.TabIndex = 42;
            // 
            // lbMedicalRecordID
            // 
            this.lbMedicalRecordID.AutoSize = true;
            this.lbMedicalRecordID.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMedicalRecordID.Location = new System.Drawing.Point(225, 98);
            this.lbMedicalRecordID.Name = "lbMedicalRecordID";
            this.lbMedicalRecordID.Size = new System.Drawing.Size(26, 22);
            this.lbMedicalRecordID.TabIndex = 43;
            this.lbMedicalRecordID.Text = "??";
            // 
            // FrPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 592);
            this.Controls.Add(this.lbMedicalRecordID);
            this.Controls.Add(this.txtDosage);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSavePrescrption);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.txtMedcationName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPrescriptionid);
            this.Controls.Add(this.label5);
            this.Name = "FrPrescription";
            this.Text = "FrPrescription";
            this.Load += new System.EventHandler(this.FrPrescription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker txtStartDate;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnSavePrescrption;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2TextBox txtFrequency;
        private Guna.UI2.WinForms.Guna2TextBox txtMedcationName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPrescriptionid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtEndDate;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;
        private Guna.UI2.WinForms.Guna2TextBox txtDosage;
        private System.Windows.Forms.Label lbMedicalRecordID;
    }
}