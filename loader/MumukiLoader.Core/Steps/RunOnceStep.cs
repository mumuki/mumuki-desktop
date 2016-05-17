namespace MumukiLoader.Core.Steps
{
	public abstract class RunOnceStep : Step
	{
		public override bool ItWorked() { return !ShouldRun; }
	}
}
