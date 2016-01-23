namespace LoggerLib.Appenders
{
	using System;
	using System.IO;
	using System.Linq;

	using LoggerLib.Layouts;
	using LoggerLib.Loggers;

	public class FileAppender : Appender
	{
		private string filePath;

		public FileAppender(ILayout layout)
			: base(layout)
		{
		}

		public FileAppender(ILayout layout, string filePath)
			: base(layout)
		{
			this.FilePath = filePath;
		}

		public string FilePath
		{
			get
			{
				return this.filePath;
			}

			set
			{
				var pathIsInvalid = Path.GetInvalidPathChars().Any(value.Contains);

				if (pathIsInvalid)
				{
					throw new ArgumentException("Invalid file path.");
				}

				this.filePath = value;
			}
		}

		public override void Append(ErrorLevel level, string message)
		{
			if (this.filePath == null)
			{
				throw new ArgumentNullException(this.FilePath, "File path is not set.");
			}

			var date = DateTime.Now;

			var dateOfError = date.ToString("d");
			var timeOfError = date.ToString("t");

			var formattedMessage = $"{dateOfError} {timeOfError} - {message}";

			var fileInfo = new FileInfo(this.FilePath);
			if (fileInfo.Exists && fileInfo.Length != 0)
			{
				formattedMessage = Environment.NewLine + formattedMessage;
			}
			
			File.AppendAllText(this.FilePath, formattedMessage);
		}
	}
}
