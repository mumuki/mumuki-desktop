﻿using System.Collections.Generic;
using MumukiLoader.Core.Helpers;
using MumukiLoader.Core.Steps;
using MumukiLoader.Core.Steps.Tasks;

namespace MumukiLoader.Core {
	public class Loader {
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
		public Result LoadAll() {
			foreach (var step in this.steps) {
				if (step.ShouldRun) {
					log.AddLine($"=> Running task '{step.Name}'...");
					var result = step.Run(log);

					logStepStatus(step, result.ToStatusString());
					if (result != Result.Success) return result;
				} else {
					logStepStatus(step, "NOT NEEDED");
				}
			}

			return Result.Success;
		}

		private void logStepStatus(Step step, string status) {
			log.AddLine($"Task: '{step.Name}': {status}");
		}
	}
}