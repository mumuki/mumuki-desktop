namespace MumukiLoader.Core.Helpers {
	public static class LoggerExtensions {
		/// <summary>
		/// Adds a line to the logger.
		/// </summary>
		public static void AddLine(this Logger self, string line) {
			self.Text = self.Text.Length != 0
				? $"{self.Text}\r\n{line}"
				: line;
		}
	}
}
