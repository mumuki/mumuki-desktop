using System.ComponentModel;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps
{
	public abstract class Step
	{
		public abstract string Name { get; }
		public abstract bool ShouldRun { get; }

		/// <summary>
		/// Runs the step and returns a success flag.
		/// </summary>
		public bool Run(Logger log)
		{
			int exitCode;
			try
			{
				exitCode = this.run();
			}
			catch (Win32Exception e)
			{
				log.AddLine($"The step finished with a win32 error: {e.Message}");
				return false;
			}
			
			if (exitCode != 0)
				log.AddLine($"The step finished with an abnormal exit code: {exitCode}");

			return exitCode == 0;
		}

		protected abstract int run();
	}
}
