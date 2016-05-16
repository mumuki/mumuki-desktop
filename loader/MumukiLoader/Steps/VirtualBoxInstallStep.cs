using MumukiLoader.Helpers;

namespace MumukiLoader.Steps
{
	internal class VirtualBoxInstallStep : Step
	{
		public bool ShouldRun => !@"Software\Oracle\VirtualBox".ExistsInRegistry();

		public void Run()
		{
			"install-virtualbox.msi".RunOnCommandLine("/qb");
		}
	}
}
