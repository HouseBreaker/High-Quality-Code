namespace LoggerLib.Appenders
{
	using System;

	using LoggerLib.Layouts;
	using LoggerLib.Loggers;

	public abstract class Appender : IAppender
	{
		protected Appender(ILayout layout)
		{
			this.Layout = layout;
		}

		public ILayout Layout { get; set; }

		public abstract void Append(ErrorLevel level, string message);
	}
}
