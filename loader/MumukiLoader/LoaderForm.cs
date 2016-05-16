using System.Windows.Forms;

namespace MumukiLoader
{
	public partial class LoaderForm : Form
	{
		public LoaderForm()
		{
			InitializeComponent();
		}

		private void LoaderForm_Load(object sender, System.EventArgs e)
		{
			new Loader().LoadAll();
		}
	}
}
