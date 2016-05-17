using System.Threading.Tasks;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks {
	public class OpenSshInstallStep : RunOnceStep {
		public override string Name => "Install Ssh";
		public override bool ShouldRun => "where ssh".RunAsCommand() != 0;

		protected override async Task<int> run(Logger log) {
			return await "install-openssh.exe".RunAsWin32("/clientonly=1 /S");
		}
	}
}
