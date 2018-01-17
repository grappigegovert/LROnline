using System.Net;
using System.Windows.Forms;

namespace Client
{
	public partial class ClientForm : Form
	{
		private Client client;
		private int fancyi;
		private Timer fancylabeltimer;

		public ClientForm(IPAddress ip, int port)
		{
			InitializeComponent();
			this.serverAddrLabel.Text = string.Join(":", ip.ToString(), port.ToString());
			this.pingLabel.Text = "";
			this.numPlayersLabel.Text = "";
			this.playerNoLabel.Text = "";
			this.statusLabel.Text = "Not connected";
			this.client = new Client(ip, port, this);
		}

		private void FancyConnect()
		{
			fancylabeltimer = new Timer();
			fancylabeltimer.Tick += fancylabeltimer_Tick;
			fancylabeltimer.Interval = 400;
			fancyi = 0;
			fancylabeltimer.Start();
			SetStatus("Connecting");
		}

		void fancylabeltimer_Tick(object sender, System.EventArgs e)
		{
			if (client.status != Shared.ClientStatus.Connecting)
			{
				fancylabeltimer.Stop();
				return;
			}
			if (++fancyi > 3)
				fancyi = 0;
			SetStatus("Connecting" + new string('.', fancyi));
		}

		public void Connect()
		{
			this.client.Connect();
			this.FancyConnect();
		}

		public void SetStatus(string status)
		{
			InvokeIfRequired(statusLabel, () => statusLabel.Text = status);
		}

		public void SetPlayerIndex(int index)
		{
			InvokeIfRequired(playerNoLabel, () => playerNoLabel.Text = index.ToString());
		}

		private static void InvokeIfRequired(Control control, MethodInvoker action)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(action);
			}
			else
			{
				action();
			}
		}

		public void End()
		{
			InvokeIfRequired(this, this.Close);
		}

		private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (client.status != Shared.ClientStatus.NotConnected)
				this.client.Disconnect();
		}
	}
}
