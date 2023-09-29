using Serilog;


namespace Fabian.Application.Services.LoggerService
{
    public class LoggerService : ILoggerService
    {
        public LoggerService() 
        {
            Logger = ConfigureLogger();
        }
        public ILogger Logger;
        private ILogger ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo
                .File("log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            return Log.Logger;
        }

        public void LogInformation(string message)
        {
            Logger.Information(message);
        }
        public void LogError(Exception ex, string message)
        {
            Logger.Error(ex, message);
        }
    }
}
