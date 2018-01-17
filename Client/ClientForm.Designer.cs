namespace Client
{
	partial class ClientForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
			this.label1 = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.serverAddrLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pingLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.numPlayersLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.playerNoLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Status:";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(72, 9);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(91, 17);
			this.statusLabel.TabIndex = 2;
			this.statusLabel.Text = "Connecting...";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "Server:";
			// 
			// serverAddrLabel
			// 
			this.serverAddrLabel.AutoSize = true;
			this.serverAddrLabel.Location = new System.Drawing.Point(72, 28);
			this.serverAddrLabel.Name = "serverAddrLabel";
			this.serverAddrLabel.Size = new System.Drawing.Size(144, 17);
			this.serverAddrLabel.TabIndex = 4;
			this.serverAddrLabel.Text = "81.124.231.38:31425";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 47);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 17);
			this.label5.TabIndex = 5;
			this.label5.Text = "Ping:";
			// 
			// pingLabel
			// 
			this.pingLabel.AutoSize = true;
			this.pingLabel.Location = new System.Drawing.Point(72, 47);
			this.pingLabel.Name = "pingLabel";
			this.pingLabel.Size = new System.Drawing.Size(42, 17);
			this.pingLabel.TabIndex = 6;
			this.pingLabel.Text = "37ms";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 66);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(129, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "Players connected:";
			// 
			// numPlayersLabel
			// 
			this.numPlayersLabel.AutoSize = true;
			this.numPlayersLabel.Location = new System.Drawing.Point(147, 66);
			this.numPlayersLabel.Name = "numPlayersLabel";
			this.numPlayersLabel.Size = new System.Drawing.Size(16, 17);
			this.numPlayersLabel.TabIndex = 8;
			this.numPlayersLabel.Text = "1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "Player no.:";
			// 
			// playerNoLabel
			// 
			this.playerNoLabel.AutoSize = true;
			this.playerNoLabel.Location = new System.Drawing.Point(94, 85);
			this.playerNoLabel.Name = "playerNoLabel";
			this.playerNoLabel.Size = new System.Drawing.Size(16, 17);
			this.playerNoLabel.TabIndex = 10;
			this.playerNoLabel.Text = "0";
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 110);
			this.Controls.Add(this.playerNoLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numPlayersLabel);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.pingLabel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.serverAddrLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ClientForm";
			this.Text = "LROnline Client";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label serverAddrLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label pingLabel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label numPlayersLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label playerNoLabel;
	}
}

