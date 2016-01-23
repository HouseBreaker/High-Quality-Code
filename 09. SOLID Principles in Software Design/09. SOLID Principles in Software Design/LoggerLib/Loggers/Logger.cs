namespace LoggerLib.Loggers
{
	using LoggerLib.Appenders;

	public class Logger : ILogger
	{
		public Logger(IAppender appender)
		{
			this.Appender = appender;
		}

		public IAppender Appender { get; set; }

		public void Debug(string message)
		{
			this.Appender.Append(ErrorLevel.Debug, message);
		}

		public void Info(string message)
		{
			this.Appender.Append(ErrorLevel.Info, message);
		}

		public void Warn(string message)
		{
			this.Appender.Append(ErrorLevel.Warn, message);
		}

		public void Error(string message)
		{
			this.Appender.Append(ErrorLevel.Error, message);
		}

		public void Critical(string message)
		{
			this.Appender.Append(ErrorLevel.Critical, message);
		}

		public void Fatal(string message)
		{
			this.Appender.Append(ErrorLevel.Fatal, message);
		}
	}
}