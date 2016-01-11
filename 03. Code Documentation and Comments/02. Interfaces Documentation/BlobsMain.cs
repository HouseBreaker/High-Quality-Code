namespace Exam
{
	using Exam.Engine;
	using Exam.Engine.Database;
	using Exam.Engine.IO;
	using Exam.Engine.IO.Interfaces;

	public static class BlobsMain
	{
		public static void Main()
		{
			IReader input = new ConsoleReader();
			IWriter output = new ConsoleWriter();
			BlobDatabase database = new BlobDatabase();
			BlobEngine engine = new BlobEngine(database, input, output);

			engine.Run();
		}
	}
}
