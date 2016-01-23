namespace LoggerLib.Layouts
{
	using LoggerLib.Loggers;

	public abstract class Layout : ILayout
	{
		public abstract string Format(ErrorLevel level, string message);
	}
}
