namespace MumukiLoader.Steps
{
	interface Step
	{
		bool ShouldRun { get; }
		void Run();
	}
}
