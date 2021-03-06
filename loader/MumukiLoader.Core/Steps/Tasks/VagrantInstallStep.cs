﻿using System.Threading.Tasks;
using MumukiLoader.Core.Helpers;

namespace MumukiLoader.Core.Steps.Tasks {
	public class VagrantInstallStep : RunOnceStep {
		public override string Name => "Install Vagrant";
		public override bool ShouldRun => "where vagrant".RunAsCommand() != 0;

		protected override async Task<int> run(Logger log) {
			var exitCode = await "install-vagrant.msi".RunAsWin32("/qb /norestart");

			return exitCode == RESTART_NEEDED
				? 0 // yeah, sure, already restarted everything :B
				: exitCode;
		}
	}
}
