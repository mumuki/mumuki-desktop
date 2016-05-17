using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps
{
	public class VagrantInstallStep : Step
	{
		public override string Name => "Install Vagrant";
		public override bool ShouldRun => "where vagrant".RunAsCommand() != 0;
		public const int RESTART_NEEDED = 3010;

		protected override int run()
		{
			var exitCode = "install-vagrant.msi".RunAsWin32("/qb /norestart");
			if (exitCode == RESTART_NEEDED) return 0; // bleh

			return exitCode;
		}
	}
}
