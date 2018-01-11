namespace Client
{
    partial class SettingsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbGameVer = new System.Windows.Forms.ComboBox();
            this.lblGameVer = new System.Windows.Forms.Label();
            this.lnkResetSettings = new System.Windows.Forms.LinkLabel();
            this.chkSkipIntroVideo = new System.Windows.Forms.CheckBox();
            this.chkOverwriteDefaults = new System.Windows.Forms.CheckBox();
            this.chkWindowedMode = new System.Windows.Forms.CheckBox();
            this.nrDefaultPort = new System.Windows.Forms.NumericUpDown();
            this.txtDefaultServerAddress = new System.Windows.Forms.TextBox();
            this.lblDefaultServerAddress = new System.Windows.Forms.Label();
            this.txtDefaultNickname = new System.Windows.Forms.TextBox();
            this.lblDefaultNickname = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblArguments = new System.Windows.Forms.Label();
            this.txtArguments = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDefaultPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtArguments);
            this.panel1.Controls.Add(this.lblArguments);
            this.panel1.Controls.Add(this.cmbGameVer);
            this.panel1.Controls.Add(this.lblGameVer);
            this.panel1.Controls.Add(this.lnkResetSettings);
            this.panel1.Controls.Add(this.chkSkipIntroVideo);
            this.panel1.Controls.Add(this.chkOverwriteDefaults);
            this.panel1.Controls.Add(this.chkWindowedMode);
            this.panel1.Controls.Add(this.nrDefaultPort);
            this.panel1.Controls.Add(this.txtDefaultServerAddress);
            this.panel1.Controls.Add(this.lblDefaultServerAddress);
            this.panel1.Controls.Add(this.txtDefaultNickname);
            this.panel1.Controls.Add(this.lblDefaultNickname);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 308);
            this.panel1.TabIndex = 0;
            // 
            // cmbGameVer
            // 
            this.cmbGameVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGameVer.FormattingEnabled = true;
            this.cmbGameVer.Items.AddRange(new object[] {
            "auto detect",
            "force 1999-nodrm",
            "force 2001"});
            this.cmbGameVer.Location = new System.Drawing.Point(119, 196);
            this.cmbGameVer.Name = "cmbGameVer";
            this.cmbGameVer.Size = new System.Drawing.Size(135, 24);
            this.cmbGameVer.TabIndex = 12;
            // 
            // lblGameVer
            // 
            this.lblGameVer.AutoSize = true;
            this.lblGameVer.Location = new System.Drawing.Point(17, 199);
            this.lblGameVer.Name = "lblGameVer";
            this.lblGameVer.Size = new System.Drawing.Size(102, 17);
            this.lblGameVer.TabIndex = 11;
            this.lblGameVer.Text = "Game Version:";
            // 
            // lnkResetSettings
            // 
            this.lnkResetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkResetSettings.AutoSize = true;
            this.lnkResetSettings.Location = new System.Drawing.Point(340, 6);
            this.lnkResetSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkResetSettings.Name = "lnkResetSettings";
            this.lnkResetSettings.Size = new System.Drawing.Size(98, 17);
            this.lnkResetSettings.TabIndex = 10;
            this.lnkResetSettings.TabStop = true;
            this.lnkResetSettings.Text = "Reset settings";
            this.lnkResetSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResetSettings_LinkClicked);
            // 
            // chkSkipIntroVideo
            // 
            this.chkSkipIntroVideo.AutoSize = true;
            this.chkSkipIntroVideo.Location = new System.Drawing.Point(20, 143);
            this.chkSkipIntroVideo.Margin = new System.Windows.Forms.Padding(4);
            this.chkSkipIntroVideo.Name = "chkSkipIntroVideo";
            this.chkSkipIntroVideo.Size = new System.Drawing.Size(127, 21);
            this.chkSkipIntroVideo.TabIndex = 9;
            this.chkSkipIntroVideo.Text = "Skip intro video";
            this.chkSkipIntroVideo.UseVisualStyleBackColor = true;
            // 
            // chkOverwriteDefaults
            // 
            this.chkOverwriteDefaults.AutoSize = true;
            this.chkOverwriteDefaults.Location = new System.Drawing.Point(20, 171);
            this.chkOverwriteDefaults.Margin = new System.Windows.Forms.Padding(4);
            this.chkOverwriteDefaults.Name = "chkOverwriteDefaults";
            this.chkOverwriteDefaults.Size = new System.Drawing.Size(277, 21);
            this.chkOverwriteDefaults.TabIndex = 8;
            this.chkOverwriteDefaults.Text = "Overwrite defaults when joining a game";
            this.chkOverwriteDefaults.UseVisualStyleBackColor = true;
            // 
            // chkWindowedMode
            // 
            this.chkWindowedMode.AutoSize = true;
            this.chkWindowedMode.Location = new System.Drawing.Point(20, 114);
            this.chkWindowedMode.Margin = new System.Windows.Forms.Padding(4);
            this.chkWindowedMode.Name = "chkWindowedMode";
            this.chkWindowedMode.Size = new System.Drawing.Size(239, 21);
            this.chkWindowedMode.TabIndex = 7;
            this.chkWindowedMode.Text = "Launch game in Windowed Mode";
            this.chkWindowedMode.UseVisualStyleBackColor = true;
            // 
            // nrDefaultPort
            // 
            this.nrDefaultPort.Location = new System.Drawing.Point(253, 82);
            this.nrDefaultPort.Margin = new System.Windows.Forms.Padding(4);
            this.nrDefaultPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nrDefaultPort.Name = "nrDefaultPort";
            this.nrDefaultPort.Size = new System.Drawing.Size(95, 22);
            this.nrDefaultPort.TabIndex = 6;
            // 
            // txtDefaultServerAddress
            // 
            this.txtDefaultServerAddress.Location = new System.Drawing.Point(20, 82);
            this.txtDefaultServerAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtDefaultServerAddress.Name = "txtDefaultServerAddress";
            this.txtDefaultServerAddress.Size = new System.Drawing.Size(224, 22);
            this.txtDefaultServerAddress.TabIndex = 5;
            // 
            // lblDefaultServerAddress
            // 
            this.lblDefaultServerAddress.AutoSize = true;
            this.lblDefaultServerAddress.Location = new System.Drawing.Point(16, 63);
            this.lblDefaultServerAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaultServerAddress.Name = "lblDefaultServerAddress";
            this.lblDefaultServerAddress.Size = new System.Drawing.Size(159, 17);
            this.lblDefaultServerAddress.TabIndex = 2;
            this.lblDefaultServerAddress.Text = "Default Server Address:";
            // 
            // txtDefaultNickname
            // 
            this.txtDefaultNickname.Location = new System.Drawing.Point(20, 31);
            this.txtDefaultNickname.Margin = new System.Windows.Forms.Padding(4);
            this.txtDefaultNickname.Name = "txtDefaultNickname";
            this.txtDefaultNickname.Size = new System.Drawing.Size(224, 22);
            this.txtDefaultNickname.TabIndex = 1;
            // 
            // lblDefaultNickname
            // 
            this.lblDefaultNickname.AutoSize = true;
            this.lblDefaultNickname.Location = new System.Drawing.Point(16, 11);
            this.lblDefaultNickname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaultNickname.Name = "lblDefaultNickname";
            this.lblDefaultNickname.Size = new System.Drawing.Size(123, 17);
            this.lblDefaultNickname.TabIndex = 0;
            this.lblDefaultNickname.Text = "Default Nickname:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(338, 316);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(227, 316);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblArguments
            // 
            this.lblArguments.AutoSize = true;
            this.lblArguments.Location = new System.Drawing.Point(17, 226);
            this.lblArguments.Name = "lblArguments";
            this.lblArguments.Size = new System.Drawing.Size(145, 17);
            this.lblArguments.TabIndex = 13;
            this.lblArguments.Text = "Additional arguments:";
            // 
            // txtArguments
            // 
            this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArguments.Location = new System.Drawing.Point(19, 246);
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.Size = new System.Drawing.Size(417, 22);
            this.txtArguments.TabIndex = 14;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 354);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDefaultPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDefaultServerAddress;
        private System.Windows.Forms.TextBox txtDefaultNickname;
        private System.Windows.Forms.Label lblDefaultNickname;
        private System.Windows.Forms.NumericUpDown nrDefaultPort;
        private System.Windows.Forms.TextBox txtDefaultServerAddress;
        private System.Windows.Forms.CheckBox chkWindowedMode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkOverwriteDefaults;
        private System.Windows.Forms.CheckBox chkSkipIntroVideo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel lnkResetSettings;
        private System.Windows.Forms.ComboBox cmbGameVer;
        private System.Windows.Forms.Label lblGameVer;
        private System.Windows.Forms.TextBox txtArguments;
        private System.Windows.Forms.Label lblArguments;
    }
}