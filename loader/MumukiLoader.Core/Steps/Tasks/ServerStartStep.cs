using System.Threading.Tasks;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks {
	public class ServerStartStep : RunAlwaysStep {
		public override string Name => "Server start";

		protected override async Task<int> run(Logger log) {
			return await "vagrant provision".RunAsCommand(log);
		}
	}
}
