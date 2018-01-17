namespace Client
{
	partial class LauncherForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
			this.ipTextBox = new System.Windows.Forms.TextBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.launchButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// ipTextBox
			// 
			this.ipTextBox.Location = new System.Drawing.Point(138, 234);
			this.ipTextBox.Name = "ipTextBox";
			this.ipTextBox.Size = new System.Drawing.Size(140, 22);
			this.ipTextBox.TabIndex = 0;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(284, 234);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(67, 22);
			this.numericUpDown1.TabIndex = 1;
			this.numericUpDown1.Value = new decimal(new int[] {
            31425,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(135, 214);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Server IP:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(281, 214);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port:";
			// 
			// launchButton
			// 
			this.launchButton.Location = new System.Drawing.Point(176, 300);
			this.launchButton.Name = "launchButton";
			this.launchButton.Size = new System.Drawing.Size(143, 58);
			this.launchButton.TabIndex = 4;
			this.launchButton.Text = "Launch";
			this.launchButton.UseVisualStyleBackColor = true;
			this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
			// 
			// LauncherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 430);
			this.Controls.Add(this.launchButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.ipTextBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LauncherForm";
			this.Text = "LROnline Launcher";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox ipTextBox;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button launchButton;
	}
}