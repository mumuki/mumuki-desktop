using System.Threading.Tasks;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks {
	public class VagrantUpStep : RunAlwaysStep {
		public override string Name => "Vagrant up";

		protected override async Task<int> run(Logger log) {
			return await "vagrant up --no-provision".RunAsCommand(log);
		}
	}
}
