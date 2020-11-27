using Discord;
using System;
using System.Threading.Tasks;
using System.IO;

namespace Zachary_Childers_CPT_185_Final.Services
{
    public class Logger
    {

        internal Task Log(LogSeverity severity, string source, string message, Exception exception = null)
        {
            Log(new LogMessage(severity, source, message, exception));
            return Task.CompletedTask;
        }

        internal Task Log(LogMessage logMessage)
        {
            string message = String.Concat(DateTime.Now.ToShortTimeString(), " [", logMessage.Source, "] ", logMessage.Message);

            return Task.CompletedTask;
        }
        // Possibly use this later
        //  private ConsoleColor SeverityToConsoleColor(LogSeverity severity)
        //  {
        //      switch (severity)
        //      {
        //          case LogSeverity.Critical:
        //              return ConsoleColor.Red;
        //          case LogSeverity.Debug:
        //              return ConsoleColor.Blue;
        //          case LogSeverity.Error:
        //              return ConsoleColor.Yellow;
        //          case LogSeverity.Info:
        //              return ConsoleColor.Blue;
        //          case LogSeverity.Verbose:
        //              return ConsoleColor.Green;
        //          case LogSeverity.Warning:
        //              return ConsoleColor.Magenta;
        //          default:
        //              return ConsoleColor.White;
        //      }
        //  }


    }
}