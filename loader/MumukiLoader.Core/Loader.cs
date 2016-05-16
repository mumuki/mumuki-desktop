using System.Collections.Generic;
using MumukiLoader.Core.Helpers;
using MumukiLoader.Core.Steps;

namespace MumukiLoader.Core
{
	public class Loader
	{
		private readonly IEnumerable<Step> steps = new List<Step>
		{
			new VirtualBoxInstallStep(),
			new GitBashInstallStep()
		};

		/// <summary>
		/// Loads (and install if needed) all the software needed to load Mumuki. Returns a success flag.
		/// </summary>
		public bool LoadAll(Logger log)
		{
			foreach (var step in this.steps)
			{
				if (step.ShouldRun)
				{
					log.AddLine($"=> Running task '{step.Name}'...");
					var success = step.Run(log);
					var itStillNeedsRun = step.ShouldRun;

					log.AddLine($"=> Task '{step.Name}': " + (success && !itStillNeedsRun ? "SUCCESS" : "ERROR"));
					if (success & itStillNeedsRun)
						log.AddLine("=> Seems like after running, the task still needs to run. The load can't continue.");

					if (!success || itStillNeedsRun) return false;
				}
				else
				{
					log.AddLine($"Task: '{step.Name}': NOT NEEDED");
				}
			}

			return true;
		}
	}
}
