using LoggerLib.Layouts;

namespace LoggerLib.Appenders
{
	using System;
	using System.Text;

	using LoggerLib.Loggers;

	public class ConsoleAppender : Appender
	{
		public ConsoleAppender(ILayout layout)
			: base(layout)
		{
		}

		public override void Append(ErrorLevel level, string message)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(this.Layout.Format(level, message));

			Console.WriteLine(sb.ToString());
		}
	}
}