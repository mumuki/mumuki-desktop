using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks
{
	public class VirtualBoxInstallStep : RunOnceStep
	{
		public override string Name => "Install VirtualBox";
		public override bool ShouldRun => !@"Software\Oracle\VirtualBox".ExistsInRegistry();

		protected override int run(Logger log)
		{
			return "install-virtualbox.msi".RunAsWin32("/qb");
		}
	}
}
