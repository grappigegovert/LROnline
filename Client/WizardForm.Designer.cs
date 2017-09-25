namespace Client
{
	partial class WizardForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardForm));
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.pnlIntro = new System.Windows.Forms.Panel();
			this.lblIntroContent = new System.Windows.Forms.Label();
			this.lblIntroTitle = new System.Windows.Forms.Label();
			this.pnlIdentify = new System.Windows.Forms.Panel();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblIdentifyContent = new System.Windows.Forms.Label();
			this.lblIdentifyTitle = new System.Windows.Forms.Label();
			this.pnlFinished = new System.Windows.Forms.Panel();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.lblFinished = new System.Windows.Forms.Label();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.btnFinish = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabIntro = new System.Windows.Forms.TabPage();
			this.tabIdentify = new System.Windows.Forms.TabPage();
			this.tabFinished = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
			this.pnlIntro.SuspendLayout();
			this.pnlIdentify.SuspendLayout();
			this.pnlFinished.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabIntro.SuspendLayout();
			this.tabIdentify.SuspendLayout();
			this.tabFinished.SuspendLayout();
			this.SuspendLayout();
			// 
			// picLogo
			// 
			this.picLogo.Image = global::Client.Properties.Resources.lego;
			this.picLogo.Location = new System.Drawing.Point(13, 35);
			this.picLogo.Margin = new System.Windows.Forms.Padding(4);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(181, 167);
			this.picLogo.TabIndex = 5;
			this.picLogo.TabStop = false;
			// 
			// pnlIntro
			// 
			this.pnlIntro.Controls.Add(this.lblIntroContent);
			this.pnlIntro.Controls.Add(this.lblIntroTitle);
			this.pnlIntro.Location = new System.Drawing.Point(205, 15);
			this.pnlIntro.Margin = new System.Windows.Forms.Padding(4);
			this.pnlIntro.Name = "pnlIntro";
			this.pnlIntro.Size = new System.Drawing.Size(637, 167);
			this.pnlIntro.TabIndex = 7;
			// 
			// lblIntroContent
			// 
			this.lblIntroContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIntroContent.Location = new System.Drawing.Point(4, 41);
			this.lblIntroContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblIntroContent.Name = "lblIntroContent";
			this.lblIntroContent.Size = new System.Drawing.Size(629, 127);
			this.lblIntroContent.TabIndex = 8;
			this.lblIntroContent.Text = resources.GetString("lblIntroContent.Text");
			// 
			// lblIntroTitle
			// 
			this.lblIntroTitle.AutoSize = true;
			this.lblIntroTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIntroTitle.Location = new System.Drawing.Point(0, 0);
			this.lblIntroTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblIntroTitle.Name = "lblIntroTitle";
			this.lblIntroTitle.Size = new System.Drawing.Size(387, 42);
			this.lblIntroTitle.TabIndex = 7;
			this.lblIntroTitle.Text = "LEGO Racers Online";
			// 
			// pnlIdentify
			// 
			this.pnlIdentify.Controls.Add(this.lblStatus);
			this.pnlIdentify.Controls.Add(this.lblIdentifyContent);
			this.pnlIdentify.Controls.Add(this.lblIdentifyTitle);
			this.pnlIdentify.Location = new System.Drawing.Point(205, 15);
			this.pnlIdentify.Margin = new System.Windows.Forms.Padding(4);
			this.pnlIdentify.Name = "pnlIdentify";
			this.pnlIdentify.Size = new System.Drawing.Size(637, 167);
			this.pnlIdentify.TabIndex = 9;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(4, 106);
			this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(269, 25);
			this.lblStatus.TabIndex = 9;
			this.lblStatus.Text = "Waiting for the game to start...";
			// 
			// lblIdentifyContent
			// 
			this.lblIdentifyContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIdentifyContent.Location = new System.Drawing.Point(4, 41);
			this.lblIdentifyContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblIdentifyContent.Name = "lblIdentifyContent";
			this.lblIdentifyContent.Size = new System.Drawing.Size(629, 127);
			this.lblIdentifyContent.TabIndex = 8;
			this.lblIdentifyContent.Text = "In order to make everything work as expected, please run the game once so we can " +
    "identify your game installation details. After identifying, the game will close " +
    "automatically..";
			// 
			// lblIdentifyTitle
			// 
			this.lblIdentifyTitle.AutoSize = true;
			this.lblIdentifyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIdentifyTitle.Location = new System.Drawing.Point(0, 0);
			this.lblIdentifyTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblIdentifyTitle.Name = "lblIdentifyTitle";
			this.lblIdentifyTitle.Size = new System.Drawing.Size(525, 42);
			this.lblIdentifyTitle.TabIndex = 7;
			this.lblIdentifyTitle.Text = "Let\'s identify your installation";
			// 
			// pnlFinished
			// 
			this.pnlFinished.Controls.Add(this.radioButton2);
			this.pnlFinished.Controls.Add(this.radioButton1);
			this.pnlFinished.Controls.Add(this.label1);
			this.pnlFinished.Controls.Add(this.lblFinished);
			this.pnlFinished.Location = new System.Drawing.Point(205, 15);
			this.pnlFinished.Margin = new System.Windows.Forms.Padding(4);
			this.pnlFinished.Name = "pnlFinished";
			this.pnlFinished.Size = new System.Drawing.Size(637, 167);
			this.pnlFinished.TabIndex = 9;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(504, 145);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(106, 21);
			this.radioButton2.TabIndex = 10;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "1999-nodrm";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(504, 121);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(61, 21);
			this.radioButton1.TabIndex = 9;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "2001";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(4, 41);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(629, 127);
			this.label1.TabIndex = 8;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// lblFinished
			// 
			this.lblFinished.AutoSize = true;
			this.lblFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFinished.Location = new System.Drawing.Point(0, 0);
			this.lblFinished.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFinished.Name = "lblFinished";
			this.lblFinished.Size = new System.Drawing.Size(267, 42);
			this.lblFinished.TabIndex = 7;
			this.lblFinished.Text = "We\'re finished";
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnConfirm.Location = new System.Drawing.Point(709, 185);
			this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(133, 28);
			this.btnConfirm.TabIndex = 4;
			this.btnConfirm.Text = "Got it, let\'s go!";
			this.btnConfirm.UseVisualStyleBackColor = true;
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnNext
			// 
			this.btnNext.Enabled = false;
			this.btnNext.Location = new System.Drawing.Point(709, 185);
			this.btnNext.Margin = new System.Windows.Forms.Padding(4);
			this.btnNext.Name = "btnNext";
			this.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnNext.Size = new System.Drawing.Size(133, 28);
			this.btnNext.TabIndex = 5;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// btnFinish
			// 
			this.btnFinish.Location = new System.Drawing.Point(709, 185);
			this.btnFinish.Margin = new System.Windows.Forms.Padding(4);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnFinish.Size = new System.Drawing.Size(133, 28);
			this.btnFinish.TabIndex = 6;
			this.btnFinish.Text = "Finish";
			this.btnFinish.UseVisualStyleBackColor = true;
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabIntro);
			this.tabControl1.Controls.Add(this.tabIdentify);
			this.tabControl1.Controls.Add(this.tabFinished);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(864, 254);
			this.tabControl1.TabIndex = 7;
			this.tabControl1.TabStop = false;
			this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
			// 
			// tabIntro
			// 
			this.tabIntro.Controls.Add(this.btnConfirm);
			this.tabIntro.Controls.Add(this.pnlIntro);
			this.tabIntro.Location = new System.Drawing.Point(4, 25);
			this.tabIntro.Name = "tabIntro";
			this.tabIntro.Padding = new System.Windows.Forms.Padding(3);
			this.tabIntro.Size = new System.Drawing.Size(856, 225);
			this.tabIntro.TabIndex = 0;
			this.tabIntro.Text = "Intro";
			// 
			// tabIdentify
			// 
			this.tabIdentify.Controls.Add(this.btnNext);
			this.tabIdentify.Controls.Add(this.pnlIdentify);
			this.tabIdentify.Location = new System.Drawing.Point(4, 25);
			this.tabIdentify.Name = "tabIdentify";
			this.tabIdentify.Padding = new System.Windows.Forms.Padding(3);
			this.tabIdentify.Size = new System.Drawing.Size(856, 225);
			this.tabIdentify.TabIndex = 1;
			this.tabIdentify.Text = "Identify";
			// 
			// tabFinished
			// 
			this.tabFinished.Controls.Add(this.button1);
			this.tabFinished.Controls.Add(this.btnFinish);
			this.tabFinished.Controls.Add(this.pnlFinished);
			this.tabFinished.Location = new System.Drawing.Point(4, 25);
			this.tabFinished.Name = "tabFinished";
			this.tabFinished.Padding = new System.Windows.Forms.Padding(3);
			this.tabFinished.Size = new System.Drawing.Size(856, 225);
			this.tabFinished.TabIndex = 2;
			this.tabFinished.Text = "Finished";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(213, 185);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(160, 28);
			this.button1.TabIndex = 10;
			this.button1.Text = "Copy md5 to clipboard";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// WizardForm
			// 
			this.AcceptButton = this.btnConfirm;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(859, 251);
			this.Controls.Add(this.picLogo);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WizardForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LEGO Racers Online";
			this.Load += new System.EventHandler(this.WizardForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
			this.pnlIntro.ResumeLayout(false);
			this.pnlIntro.PerformLayout();
			this.pnlIdentify.ResumeLayout(false);
			this.pnlIdentify.PerformLayout();
			this.pnlFinished.ResumeLayout(false);
			this.pnlFinished.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabIntro.ResumeLayout(false);
			this.tabIdentify.ResumeLayout(false);
			this.tabFinished.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.Panel pnlIntro;
		private System.Windows.Forms.Label lblIntroContent;
		private System.Windows.Forms.Label lblIntroTitle;
		private System.Windows.Forms.Panel pnlIdentify;
		private System.Windows.Forms.Label lblIdentifyContent;
		private System.Windows.Forms.Label lblIdentifyTitle;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnFinish;
		private System.Windows.Forms.Panel pnlFinished;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblFinished;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabIntro;
		private System.Windows.Forms.TabPage tabIdentify;
		private System.Windows.Forms.TabPage tabFinished;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;

	}
}