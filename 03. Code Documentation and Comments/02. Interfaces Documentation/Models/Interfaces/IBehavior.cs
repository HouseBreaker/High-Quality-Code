namespace Exam.Models.Interfaces
{
	/// <summary>
	/// Interface for models which have behaviors.
	/// </summary>
	public interface IBehavior
	{
		bool HasBeenTriggered { get; set; }

		void Trigger(Blob blob);

		void EndTurnAction(Blob blob);
	}
}
