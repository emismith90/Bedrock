using Serilog;

namespace Bedrock.Infrastructure.Logger
{
    public interface IBedrockLogManager 
    {
        ILogger CreateLogger();
    }
}
