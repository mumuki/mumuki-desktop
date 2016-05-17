using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks
{
	public class VagrantUpStep : RunAlwaysStep
	{
		public override string Name => "Vagrant up";

		protected override int run(Logger log)
		{
			return "vagrant up".RunAsCommand(log);
		}
	}
}
