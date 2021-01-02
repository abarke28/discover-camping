using Serilog;
using Serilog.Core;

namespace discover_camping.loggers
{
    public class FileLogger
    {
        public Logger Logger { get; set; }

        public FileLogger()
        {
            Logger = new LoggerConfiguration().WriteTo.File(helpers.Constants.LOG_FILE).CreateLogger();
        }
    }
}