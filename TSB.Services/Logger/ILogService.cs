using System;

namespace TSB.Services.Logger
{
    public interface ILogService
    {
        void Log<T>(T item);
        void Log<T>(T item, Action<T> callback);
    }
}
