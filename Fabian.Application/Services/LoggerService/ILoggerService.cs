

namespace Fabian.Application.Services.LoggerService
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogError(Exception ex, string message);
    }
}
