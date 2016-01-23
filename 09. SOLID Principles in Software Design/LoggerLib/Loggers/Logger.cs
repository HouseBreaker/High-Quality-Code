namespace LoggerLib.Loggers
{
	using System.Collections.Generic;

	using LoggerLib.Appenders;

	public class Logger : ILogger
	{
		private IEnumerable<IAppender> appenders;
		 
		public Logger(params IAppender[] appenders)
		{
			this.Appenders = appenders;
		}

		protected IEnumerable<IAppender> Appenders
		{
			get
			{
				// this would be slow with lots of appenders but I don't know how to both
				// encapsulate and access it w/o touching the field directly
				return new List<IAppender>(this.appenders);
			}

			private set
			{
				this.appenders = value;
			}
		}

		public void Debug(string message)
		{
			this.SendMessageToAllAppenders(ErrorLevel.Debug, message);
		}

		public void Info(string message)
		{
			this.SendMessageToAllAppenders(ErrorLevel.Info, message);
		}

		public void Warn(string message)
		{
			this.SendMessageToAllAppenders(ErrorLevel.Warn, message);
		}

		public void Error(string message)
		{
			this.SendMessageToAllAppenders(ErrorLevel.Error, message);
		}

		public void Critical(string message)
		{
			this.SendMessageToAllAppenders(ErrorLevel.Critical, message);
		}

		public void Fatal(string message)
		{
			this.SendMessageToAllAppenders(ErrorLevel.Fatal, message);
		}

		private void SendMessageToAllAppenders(ErrorLevel level, string message)
		{
			foreach (var appender in this.Appenders)
			{
				appender.Append(level, message);
			}
		}
	}
}