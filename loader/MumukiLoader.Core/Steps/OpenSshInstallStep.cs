using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps
{
	public class OpenSshInstallStep : Step
	{
		public override string Name => "Install Ssh";
		public override bool ShouldRun => "where ssh".RunAsCommand() != 0;

		protected override int run()
		{
			return "install-openssh.exe".RunAsWin32("/clientonly=1 /S");
		}
	}
}
