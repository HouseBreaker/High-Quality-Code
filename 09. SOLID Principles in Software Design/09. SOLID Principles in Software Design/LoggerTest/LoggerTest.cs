namespace LoggerTest
{
	using LoggerLib.Appenders;
	using LoggerLib.Layouts;
	using LoggerLib.Loggers;

	internal static class LoggerTest
	{
		internal static void Main()
		{
			ILayout simpleLayout = new SimpleLayout();
			IAppender consoleAppender = new ConsoleAppender(simpleLayout);
			ILogger logger = new Logger(consoleAppender);

			logger.Error("Error parsing JSON.");
			logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
		}
	}
}
