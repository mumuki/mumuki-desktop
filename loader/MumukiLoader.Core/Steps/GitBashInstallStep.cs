using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps
{
	public class GitBashInstallStep : Step
	{
		public override string Name => "Install Ssh";
		public override bool ShouldRun => "where ssh".RunAsCommand() != 0;

		protected override int run()
		{
			return "install-git.exe /verysilent /supressmsgboxes".RunAsCommand();
		}
	}
}
