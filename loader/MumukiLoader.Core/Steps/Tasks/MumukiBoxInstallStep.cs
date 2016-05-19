using System.Threading.Tasks;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks {
	public class MumukiBoxInstallStep : RunOnceStep {
		private const string BOX_NAME = "alpha";

		public override string Name => "Install mumuki.box";

		public override bool ShouldRun =>
			!"vagrant box list".RunAsCommandAndGetOutput().Contains(BOX_NAME);

		protected override async Task<int> run(Logger log) {
			return await $"vagrant box add {BOX_NAME} {BOX_NAME}.box".RunAsCommand(log);
		}
	}
}
