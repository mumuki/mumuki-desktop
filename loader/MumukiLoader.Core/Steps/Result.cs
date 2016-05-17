namespace MumukiLoader.Core.Steps {
	public enum Result {
		Success, RestartNeeded, Error
	}

	public static class ResultExtensions {
		public static string ToStatusString(this Result result)
		{
			return result.ToString().Replace("Result.", "").ToUpper();
		}
	}
}
