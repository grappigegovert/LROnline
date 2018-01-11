using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LEGORacersAPI;
using System.Globalization;

namespace API_testapp
{
    public partial class Form1 : Form
    {

        public static GameClient game;
        Timer maintimer;
		CultureInfo ci = CultureInfo.InvariantCulture;

        public Form1()
        {
            InitializeComponent();
            maintimer = new Timer();
            maintimer.Interval = 100;
            maintimer.Enabled = false;
            maintimer.Tick += maintimer_Tick;
	        InitListview();
        }

        void maintimer_Tick(object sender, EventArgs e)
        {
            initializedlabel.Text = game.InitializedType.ToString();
            isracerunninglabel.Text = game.IsRaceRunning.ToString();
            checkBox2.Checked = game.RunInBackground;
            if (game.IsRaceRunning)
            {
                groupBoxInrace.Enabled = true;
                RacePaucedLabel.Text = game.Paused.ToString();
	            UpdateListview();
            }
            else
	            groupBoxInrace.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameClient[] clients = GameClientFactory.GetActiveGameClients();
            if (clients.Length > 0)
            {
                game = clients[0];
                statuslabel.Text = "attached";
                enablestuff(true);

                game.Initialized += Game_Initialized;
            }
            else
                statuslabel.Text = "failed to attach";
        }

        private void Game_Initialized(InitializedType type)
        {
            Console.WriteLine(type.ToString());
        }

        private void enablestuff(bool value)
        {
            checkBox1.Enabled = value;
            checkBox1.Checked = value && false;
            button2.Enabled = value;
            groupBoxGlobal.Enabled = value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (game!=null)
            {
                game.Unload();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maintimer_Tick(sender, new EventArgs());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            maintimer.Enabled = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (game.Paused)
            {
                game.Paused = false;
                button3.Text = "Pause race";
            }
            else
            {
                game.Paused = true;
                button3.Text = "Unause race";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == checkBox2)
                game.RunInBackground = checkBox2.Checked;
        }

	    private void InitListview()
	    {
		    listView1.Items.AddRange(new ListViewItem[]
		    {
			    new ListViewItem(new string[] {"P1-pos-X", "0"}),
			    new ListViewItem(new string[] {"P1-pos-Y", "0"}),
			    new ListViewItem(new string[] {"P1-pos-Z", "0"}),
			    new ListViewItem(new string[] {"P1-rot-up-X", "0"}),
			    new ListViewItem(new string[] {"P1-rot-up-Y", "0"}),
			    new ListViewItem(new string[] {"P1-rot-up-Z", "0"}),
			    new ListViewItem(new string[] {"P1-rot-fwd-X", "0"}),
			    new ListViewItem(new string[] {"P1-rot-fwd-Y", "0"}),
			    new ListViewItem(new string[] {"P1-rot-fwd-Z", "0"}),
			    new ListViewItem(new string[] {"P1-spd-X", "0"}),
			    new ListViewItem(new string[] {"P1-spd-Y", "0"}),
			    new ListViewItem(new string[] {"P1-spd-Z", "0"}),
		    });
	    }

	    private void UpdateListview()
	    {
		    listView1.Items[0].SubItems[1].Text = game.drivers[0].X.ToString(ci);
		    listView1.Items[1].SubItems[1].Text = game.drivers[0].Y.ToString(ci);
		    listView1.Items[2].SubItems[1].Text = game.drivers[0].Z.ToString(ci);
		    listView1.Items[3].SubItems[1].Text = game.drivers[0].Up_X.ToString(ci);
		    listView1.Items[4].SubItems[1].Text = game.drivers[0].Up_Y.ToString(ci);
		    listView1.Items[5].SubItems[1].Text = game.drivers[0].Up_Z.ToString(ci);
		    listView1.Items[6].SubItems[1].Text = game.drivers[0].Forward_X.ToString(ci);
		    listView1.Items[7].SubItems[1].Text = game.drivers[0].Forward_Y.ToString(ci);
		    listView1.Items[8].SubItems[1].Text = game.drivers[0].Forward_Z.ToString(ci);
		    listView1.Items[9].SubItems[1].Text = game.drivers[0].SpeedX.ToString(ci);
		    listView1.Items[10].SubItems[1].Text = game.drivers[0].SpeedY.ToString(ci);
		    listView1.Items[11].SubItems[1].Text = game.drivers[0].SpeedZ.ToString(ci);
	    }
    }
}
