using System.Windows.Forms;
using MumukiLoader.Core;

namespace MumukiLoader
{
	public partial class LoaderForm : Form
	{
		private bool loaded;
		 
		public LoaderForm()
		{
			InitializeComponent();
		}

		private void LoaderForm_Shown(object sender, System.EventArgs e)
		{
			new Loader().LoadAll(new TextBoxLogger(this.txtShell));
			this.loaded = true;
		}

		private void LoaderForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!loaded) e.Cancel = true;
		}
	}
}
