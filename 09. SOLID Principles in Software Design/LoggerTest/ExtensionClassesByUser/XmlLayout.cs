namespace LoggerTest.ExtensionClassesByUser
{
	using System;
	using System.Text;

	using LoggerLib.Layouts;
	using LoggerLib.Loggers;

	public class XmlLayout : Layout
	{
		public override string Format(ErrorLevel level, string message)
		{
			StringBuilder sb = new StringBuilder();

			const string Tab = "    ";

			sb.AppendLine("<log>");
			sb.AppendFormat(Tab + "{0}{1}{2}\n", "<date>", DateTime.Now, "</date>");
			sb.AppendFormat(Tab + "{0}{1}{2}\n", "<level>", level, "</level>");
			sb.AppendFormat(Tab + "{0}{1}{2}\n", "<message>", message, "</message>");
			sb.Append("</log>");

			return sb.ToString();
		}
	}
}
