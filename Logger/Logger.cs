using System;

namespace Logger
{
	public class Logger : ILogger
	{
		public void Log(string message)
		{
			return;
		}

		public void LogError(Exception exception)
		{
			return;
		}

		public void LogError(string nessage, Exception exception)
		{
			return;
		}
	}
}
