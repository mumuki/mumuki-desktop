namespace MumukiLoader.Core.Steps {
	public abstract class RunOnceStep : Step {
		protected override bool itWorked() { return !this.ShouldRun; }
	}
}
