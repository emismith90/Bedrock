using Bedrock.Infrastructure.Configuration.Options;
using Serilog;
using Serilog.Events;

namespace Bedrock.Infrastructure.Logger
{
    public class BedrockLogManager : IBedrockLogManager
    {
        private readonly LoggingOptions _loggingOptions;
        public BedrockLogManager(LoggingOptions loggingOptions)
        {
            this._loggingOptions = loggingOptions;
        }

        public ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .MinimumLevel.Is(this._loggingOptions.LogLevel)
                    .WriteTo.Seq(this._loggingOptions.SeqUrl)
                    .CreateLogger();
        }
    }
}
