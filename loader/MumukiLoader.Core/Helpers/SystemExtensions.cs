using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace MumukiLoader.Core.Helpers
{
	public static class SystemExtensions
	{
		/// <summary>
		/// Runs the command on command line with arguments. Returns the exit code.
		/// </summary>
		public static int RunOnCommandLine(this string self, string arguments)
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
			// or
			//while (!process.StandardOutput.EndOfStream)
			//{
			//	string line = process.StandardOutput.ReadLine();
			//	// do something with line
			//}

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
	}
}
