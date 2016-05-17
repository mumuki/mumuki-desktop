using System.Collections.Generic;
using MumukiLoader.Core.Helpers;
using MumukiLoader.Core.Steps;
using MumukiLoader.Core.Steps.Tasks;

namespace MumukiLoader.Core
{
	public class Loader
	{
		private readonly Logger log;
		private readonly IEnumerable<Step> steps = new List<Step>
		{
			new VirtualBoxInstallStep(),
			new OpenSshInstallStep(),
			new VagrantInstallStep(),
			new VagrantUpStep()
		};

		public Loader(Logger log) { this.log = log; }

		/// <summary>
		/// Loads (and install if needed) all the software needed to load Mumuki. Returns a success flag.
		/// </summary>
		public bool LoadAll()
		{
			foreach (var step in this.steps)
			{
				if (step.ShouldRun)
				{
					log.AddLine($"=> Running task '{step.Name}'...");
					var success = step.Run(log);
					var itWorked = step.ItWorked();

					logStepStatus(step, success && itWorked ? "SUCCESS" : "ERROR");
					if (success & !itWorked)
						log.AddLine("=> Seems like after running, the task still needs to run. The load can't continue.");

					if (!success || !itWorked) return false;
				}
				else
				{
					logStepStatus(step, "NOT NEEDED");
				}
			}

			return true;
		}

		/// <summary>
		/// Logs the result of a task.
		/// </summary>
		private void logStepStatus(Step step, string status)
		{
			log.AddLine($"Task: '{step.Name}': {status}");
		}
	}
}
