namespace Exam.Engine
{
	using System;

	using Exam.Engine.Database;
	using Exam.Engine.IO.Interfaces;

	public class BlobEngine
	{
		public BlobEngine(BlobDatabase blobDatabase, IReader input, IWriter output)
		{
			this.BlobDatabase = blobDatabase;
			this.Input = input;
			this.Output = output;
		}

		public BlobDatabase BlobDatabase { get; }

		public IReader Input { get; }

		public IWriter Output { get; }

		public void Run()
		{
			string input = this.Input.ReadLine();
			while (input != "drop")
			{
				try
				{
					CommandParser.ParseCommand(input, this.Output, this.BlobDatabase);
				}
				catch (Exception ex)
				{
					this.Output.WriteLine(ex.Message);
				}

				input = this.Input.ReadLine();
			}
		}
	}
}
