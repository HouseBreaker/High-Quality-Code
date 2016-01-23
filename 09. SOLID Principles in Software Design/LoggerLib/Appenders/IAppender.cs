namespace LoggerLib.Appenders
{
	using LoggerLib.Loggers;

	public interface IAppender
	{
		void Append(ErrorLevel level, string message);
	}
}
