using System.ComponentModel;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps {
	public abstract class Step {
		public abstract string Name { get; }
		public virtual bool ShouldRun => true;
		private const int RESTART_NEEDED = 3010;

		/// <summary>
		/// Runs the step and returns a result.
		/// </summary>
		public Result Run(Logger log) {
			int exitCode;
			try {
				exitCode = this.run(log);
			} catch (Win32Exception e) {
				log.AddLine($"The step finished with a win32 error: {e.Message}");
				return Result.Error;
			}

			switch (exitCode) {
				case 0:
					if (!this.itWorked()) {
						log.AddLine("Seems like after running, the task still needs to run. This is an error.");
						return Result.Error;
					}
					return Result.Success;
				case RESTART_NEEDED:
					log.AddLine("The program needs to restart the system...");
					return Result.RestartNeeded;
				default:
					log.AddLine($"The step finished with an abnormal exit code: {exitCode}");
					return Result.Error;
			}
		}

		protected abstract bool itWorked();

		protected abstract int run(Logger log);
	}
}
