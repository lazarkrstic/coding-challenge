namespace TheShop.Application.Common.Interfaces
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogDebug(string message);


    }
}
