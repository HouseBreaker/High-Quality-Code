namespace Exam.Engine.Interfaces
{
	using Exam.Engine.Database;
	using Exam.Engine.IO.Interfaces;

	/// <summary>
	/// The engine interface.
	/// </summary>
	public interface IEngine
	{
		BlobDatabase Database { get; }

		IReader Input { get; }

		IWriter Output { get; }

		void Run();
	}
}