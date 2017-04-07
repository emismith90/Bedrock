using Bedrock.Infrastructure.Extensions;
using Serilog.Events;
using System;

namespace Bedrock.Infrastructure.Configuration.Options
{
    public class LoggingOptions : OptionsBase
    {
        public LoggingOptions(IAppSetting appSettings) : base(appSettings)
        {
        }

        public string SeqUrl => GetString().Default(@"http://localhost:5341");
        public LogEventLevel LogLevel
        {
            get
            {
                var level = GetString().Default("Error");
                if (Enum.TryParse(level, out LogEventLevel logEvent))
                {
                    return logEvent;
                }

                return (LogEventLevel)Enum.ToObject(typeof(LogEventLevel), 4);
            }
        }
    }
}
