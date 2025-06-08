using Serilog;
using Serilog.Events;

namespace TestsForDemoQA.Utils
{
    public static class Logger
    {
        private static readonly Serilog.Core.Logger _log;

        static Logger()
        {
            var projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            var logDirectory = Path.Combine(projectRoot, "logs");
            Directory.CreateDirectory(logDirectory);

            var logFile = Path.Combine(logDirectory, "session.log");

            _log = new LoggerConfiguration()
                .MinimumLevel.Debug() 
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) 
                .WriteTo.File(
                    path: logFile,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    shared: true
                )
                .WriteTo.File(
                    path: Path.Combine(logDirectory, "errors.log"),
                    restrictedToMinimumLevel: LogEventLevel.Error,
                    rollingInterval: RollingInterval.Day
                )
                .CreateLogger();
        }

        public static void Info(string message) => _log.Information(message);
        public static void Error(string message) => _log.Error(message);
        public static void Debug(string message) => _log.Debug(message);
        public static void Warning(string message) => _log.Warning(message);
    }
}
