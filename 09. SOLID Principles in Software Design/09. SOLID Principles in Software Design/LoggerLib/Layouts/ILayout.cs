namespace LoggerLib.Layouts
{
	using LoggerLib.Loggers;

	public interface ILayout
	{
		string Format(ErrorLevel level, string message);
	}
}
