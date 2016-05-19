using System;
using System.Windows.Forms;
using MumukiLoader.Core;
using MumukiLoader.Core.Steps;

namespace MumukiLoader {
	public partial class LoaderForm : Form {
		private bool loaded;

		public LoaderForm() {
			InitializeComponent();
		}

		private async void LoaderForm_Shown(object sender, EventArgs e)
		{
			lblPleaseWait.Text = Locales.ValueFor("PreparingThings");
			lblState.Text = Locales.ValueFor("Loading");

			var result = await new Loader(new TextBoxLogger(this.txtShell)).LoadAll();
			tweakUiFor(result);
			if (result == Result.Success) Application.Exit();
		}

		private void LoaderForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (!this.loaded) e.Cancel = true;
		}

		private void txtShell_TextChanged(object sender, EventArgs e) {
			txtShell.SelectionStart = txtShell.Text.Length;
			txtShell.ScrollToCaret();
		}

		private void tmrFakeProgress_Tick(object sender, EventArgs e) {
			prgProgress.Value += 1;
			if (prgProgress.Value >= prgProgress.Maximum)
				prgProgress.Value = 0;
		}

		private void tweakUiFor(Result result)
		{
			lblState.Text = Locales.ValueFor(result.ToStatusString());
			this.loaded = true;
			prgProgress.Value = 100;
			tmrFakeProgress.Enabled = false;
		}
	}
}
