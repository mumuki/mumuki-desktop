using System.Windows.Forms;
using MumukiLoader.Core;
using MumukiLoader.Core.Steps;

namespace MumukiLoader {
	public partial class LoaderForm : Form {
		private bool loaded;

		public LoaderForm() {
			InitializeComponent();
		}

		private void LoaderForm_Shown(object sender, System.EventArgs e) {
			lblPleaseWait.Text = Locales.ValueFor("PreparingThings");
			lblState.Text = Locales.ValueFor("Loading");

			var result = new Loader(new TextBoxLogger(this.txtShell)).LoadAll();
			lblState.Text = Locales.ValueFor(result.ToStatusString());
			loaded = true;
		}

		private void LoaderForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (!loaded) e.Cancel = true;
		}
	}
}
