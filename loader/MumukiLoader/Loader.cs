using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MumukiLoader.Steps;

namespace MumukiLoader
{
	internal class Loader
	{
		/// <summary>
		/// Loads (and install if needed) all the software needed to load Mumuki.
		/// </summary>
		public void LoadAll()
		{
			//var hasSsh = "where ssh".RunOnCommandLine() ==  0;
			var vb = new VirtualBoxInstallStep();

			var assembly = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (vb.ShouldRun)
			{
				vb.Run();
			}
			else
			{
				MessageBox.Show("No hizo falta");
			}
		}
	}
}
