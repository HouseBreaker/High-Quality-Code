namespace LoggerLib.Layouts
{
	using System;

	using LoggerLib.Loggers;

	public class SimpleLayout : Layout
	{
		public override string Format(ErrorLevel level, string message)
		{
			// <date-time> - <report level> - <message>
			var date = DateTime.Now;

			var formatString = $"{date} - {level} - {message}";

			return formatString;
		}
	}
}
