using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks
{
	public class OpenSshInstallStep : RunOnceStep
	{
		public override string Name => "Install Ssh";
		public override bool ShouldRun => "where ssh".RunAsCommand() != 0;

		protected override int run(Logger log)
		{
			return "install-openssh.exe".RunAsWin32("/clientonly=1 /S");
		}
	}
}
