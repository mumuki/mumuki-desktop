using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks {
	public class VagrantInstallStep : RunOnceStep {
		public override string Name => "Install Vagrant";
		public override bool ShouldRun => "where vagrant".RunAsCommand() != 0;

		protected override int run(Logger log) {
			return "install-vagrant.msi".RunAsWin32("/qb /norestart");
		}
	}
}
