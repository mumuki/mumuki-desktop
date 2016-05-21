using System.Threading.Tasks;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks {
	public class ChromeInstallStep : RunOnceStep {
		public override string Name => "Install Chrome";
		public override bool ShouldRun => !@"Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe".ExistsInRegistry();

		protected override async Task<int> run(Logger log) {
			return await "install-chrome.msi".RunAsWin32("/qb");
		}
	}
}
