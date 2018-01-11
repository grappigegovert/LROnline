namespace API_testapp
{
    partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.statuslabel = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.isracerunninglabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.initializedlabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.RacePaucedLabel = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBoxInrace = new System.Windows.Forms.GroupBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBoxGlobal = new System.Windows.Forms.GroupBox();
			this.groupBoxInrace.SuspendLayout();
			this.groupBoxGlobal.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(13, 13);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(199, 30);
			this.button1.TabIndex = 0;
			this.button1.Text = "Attach to running process";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(220, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Status:";
			// 
			// statuslabel
			// 
			this.statuslabel.AutoSize = true;
			this.statuslabel.Location = new System.Drawing.Point(280, 20);
			this.statuslabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.statuslabel.Name = "statuslabel";
			this.statuslabel.Size = new System.Drawing.Size(89, 17);
			this.statuslabel.TabIndex = 2;
			this.statuslabel.Text = "Not attached";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(11, 61);
			this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(106, 21);
			this.checkBox2.TabIndex = 9;
			this.checkBox2.Text = "No minimize";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// isracerunninglabel
			// 
			this.isracerunninglabel.AutoSize = true;
			this.isracerunninglabel.Location = new System.Drawing.Point(127, 41);
			this.isracerunninglabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.isracerunninglabel.Name = "isracerunninglabel";
			this.isracerunninglabel.Size = new System.Drawing.Size(38, 17);
			this.isracerunninglabel.TabIndex = 3;
			this.isracerunninglabel.Text = "false";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 41);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "IsRaceRunning =";
			// 
			// initializedlabel
			// 
			this.initializedlabel.AutoSize = true;
			this.initializedlabel.Location = new System.Drawing.Point(84, 25);
			this.initializedlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.initializedlabel.Name = "initializedlabel";
			this.initializedlabel.Size = new System.Drawing.Size(38, 17);
			this.initializedlabel.TabIndex = 1;
			this.initializedlabel.Text = "false";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 25);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Initialized = ";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(585, 15);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(83, 28);
			this.button2.TabIndex = 4;
			this.button2.Text = "Timer tick";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(511, 19);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(66, 21);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "Timer";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 25);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "RacePaused = ";
			// 
			// RacePaucedLabel
			// 
			this.RacePaucedLabel.AutoSize = true;
			this.RacePaucedLabel.Location = new System.Drawing.Point(111, 25);
			this.RacePaucedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.RacePaucedLabel.Name = "RacePaucedLabel";
			this.RacePaucedLabel.Size = new System.Drawing.Size(38, 17);
			this.RacePaucedLabel.TabIndex = 5;
			this.RacePaucedLabel.Text = "false";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(200, 19);
			this.button3.Margin = new System.Windows.Forms.Padding(4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(100, 28);
			this.button3.TabIndex = 6;
			this.button3.Text = "Pause race";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBoxInrace
			// 
			this.groupBoxInrace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxInrace.Controls.Add(this.listView1);
			this.groupBoxInrace.Controls.Add(this.label3);
			this.groupBoxInrace.Controls.Add(this.RacePaucedLabel);
			this.groupBoxInrace.Controls.Add(this.button3);
			this.groupBoxInrace.Enabled = false;
			this.groupBoxInrace.Location = new System.Drawing.Point(281, 50);
			this.groupBoxInrace.Name = "groupBoxInrace";
			this.groupBoxInrace.Size = new System.Drawing.Size(404, 280);
			this.groupBoxInrace.TabIndex = 8;
			this.groupBoxInrace.TabStop = false;
			this.groupBoxInrace.Text = "In-Race";
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(6, 99);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(392, 175);
			this.listView1.TabIndex = 7;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Variable";
			this.columnHeader1.Width = 172;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 181;
			// 
			// groupBoxGlobal
			// 
			this.groupBoxGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBoxGlobal.Controls.Add(this.checkBox2);
			this.groupBoxGlobal.Controls.Add(this.label2);
			this.groupBoxGlobal.Controls.Add(this.initializedlabel);
			this.groupBoxGlobal.Controls.Add(this.isracerunninglabel);
			this.groupBoxGlobal.Controls.Add(this.label4);
			this.groupBoxGlobal.Location = new System.Drawing.Point(0, 50);
			this.groupBoxGlobal.Name = "groupBoxGlobal";
			this.groupBoxGlobal.Size = new System.Drawing.Size(275, 280);
			this.groupBoxGlobal.TabIndex = 9;
			this.groupBoxGlobal.TabStop = false;
			this.groupBoxGlobal.Text = "Global";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(685, 330);
			this.Controls.Add(this.groupBoxGlobal);
			this.Controls.Add(this.groupBoxInrace);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statuslabel);
			this.Controls.Add(this.button1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(703, 377);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.groupBoxInrace.ResumeLayout(false);
			this.groupBoxInrace.PerformLayout();
			this.groupBoxGlobal.ResumeLayout(false);
			this.groupBoxGlobal.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label statuslabel;
        private System.Windows.Forms.Label initializedlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label isracerunninglabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label RacePaucedLabel;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.GroupBox groupBoxInrace;
		private System.Windows.Forms.GroupBox groupBoxGlobal;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

