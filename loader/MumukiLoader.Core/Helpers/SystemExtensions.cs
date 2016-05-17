using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace MumukiLoader.Core.Helpers
{
	public static class SystemExtensions
	{
		/// <summary>
		/// Runs the command as a Win32 application. Returns the exit code.
		/// </summary>
		public static int RunAsWin32(this string self, string arguments)
		{
			var process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					CreateNoWindow = true,
					WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
					FileName = self,
					Arguments = arguments
				}
			};

			process.Start();
			process.WaitForExit();

			return process.ExitCode;
		}

		/// <summary>
		/// Runs the command on the command line. Returns the exit code.
		/// </summary>
		public static int RunAsCommand(this string self)
		{
			var process = startCommand(self);
			process.WaitForExit();
			return process.ExitCode;
		}

		/// <summary>
		/// Runs the command on the command line and logs the stdout. Returns the exit code.
		/// </summary>
		public static int RunAsCommand(this string self, Logger log)
		{
			var process = startCommand(self);
			while (!process.StandardOutput.EndOfStream)
				log.AddLine(process.StandardOutput.ReadLine());
			process.WaitForExit();
			return process.ExitCode;
		}

		/// <summary>
		/// Determine if the key exists in the Registry.
		/// </summary>
		public static bool ExistsInRegistry(this string self)
		{
			using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
				return hklm.OpenSubKey(self) != null;
		}

		private static Process startCommand(string command)
		{
			var process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
					FileName = "cmd.exe",
					Arguments = $"/C {command}"
				}
			};
			process.Start();
			return process;
		}
	}
}
