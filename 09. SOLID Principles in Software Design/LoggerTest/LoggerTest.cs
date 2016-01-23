namespace LoggerTest
{
	using global::LoggerTest.ExtensionClassesByUser;

	using LoggerLib.Appenders;
	using LoggerLib.Layouts;
	using LoggerLib.Loggers;

	internal static class LoggerTest
	{
		internal static void Main()
		{
			var simpleLayout = new SimpleLayout();
			var consoleAppender = new ConsoleAppender(simpleLayout);
			var fileAppender = new FileAppender(simpleLayout, "log.txt");
			var logger = new Logger(consoleAppender, fileAppender);
			logger.Error("Error parsing JSON.");
			logger.Info(string.Format("User {0} successfully registered.", "Pesho"));

			var xmlLayout = new XmlLayout();
			var appender = new ConsoleAppender(xmlLayout);
			var xmlLogger = new Logger(appender);

			xmlLogger.Fatal("mscorlib.dll does not respond");
			xmlLogger.Critical("No connection string found in App.config");
		}
	}
}