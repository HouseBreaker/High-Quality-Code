namespace Exam.Engine.IO.Interfaces
{
	/// <summary>
	/// Generic input writer.
	/// </summary>
	public interface IWriter
	{
		void Write(string format, params object[] parameters);

		void WriteLine(string format, params object[] parameters);
	}
}
