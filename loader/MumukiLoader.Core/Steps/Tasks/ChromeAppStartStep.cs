using System.Threading.Tasks;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks {
	public class ChromeAppStart : RunAlwaysStep {
		public override string Name => "Chrome app start";

		protected override async Task<int> run(Logger log) {
			return await "start chrome --app=\"http://localhost:3000\"".RunAsCommand(log);
		}
	}
}
