using System.ComponentModel;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps
{
	public abstract class Step
	{
		public abstract string Name { get; }
		public virtual bool ShouldRun => true;
		private const int RESTART_NEEDED = 3010;

		/// <summary>
		/// Runs the step and returns a success flag.
		/// </summary>
		public bool Run(Logger log)
		{
			int exitCode;
			try
			{
				exitCode = this.run(log);
			}
			catch (Win32Exception e)
			{
				log.AddLine($"The step finished with a win32 error: {e.Message}");
				return false;
			}
			
			if (exitCode != 0)
				log.AddLine(exitCode == RESTART_NEEDED
					? "The program needs to restart the system..."
					: $"The step finished with an abnormal exit code: {exitCode}"
				);

			return exitCode == 0;
		}

		/// <summary>
		/// Checks after run, if the step still needs to run.
		/// </summary>
		/// <returns></returns>
		public abstract bool ItWorked();

		protected abstract int run(Logger log);
	}
}
