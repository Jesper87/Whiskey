﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface ILogger
    {
	    void Log(string message);
		void LogError(string nessage, Exception exception);
		void LogError(Exception exception);

	}
}