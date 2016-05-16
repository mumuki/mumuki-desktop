using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps
{
	public class VirtualBoxInstallStep : Step
	{
		public override string Name => "Install VirtualBox";
		public override bool ShouldRun => !@"Software\Oracle\VirtualBox".ExistsInRegistry();

		protected override int run()
		{
			return "install-virtualbox.msi".RunAsWin32("/qb");
		}
	}
}
