using System.Windows.Forms;
using MumukiLoader.Core;
using MumukiLoader.Core.Steps;

namespace MumukiLoader {
	public partial class LoaderForm : Form {
		private bool loaded;

		public LoaderForm() {
			InitializeComponent();
		}

		private async void LoaderForm_Shown(object sender, System.EventArgs e) {
			lblPleaseWait.Text = Locales.ValueFor("PreparingThings");
			lblState.Text = Locales.ValueFor("Loading");

			var result = await new Loader(new TextBoxLogger(this.txtShell)).LoadAll();
			lblState.Text = Locales.ValueFor(result.ToStatusString());
			loaded = true;
		}

		private void LoaderForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (!loaded) e.Cancel = true;
		}

		private void txtShell_TextChanged(object sender, System.EventArgs e) {
			txtShell.SelectionStart = txtShell.Text.Length;
			txtShell.ScrollToCaret();
		}

		private void tmrFakeProgress_Tick(object sender, System.EventArgs e) {
			prgProgress.Value += 1;
			if (prgProgress.Value >= prgProgress.Maximum)
				prgProgress.Value = 0;
		}
	}
}
