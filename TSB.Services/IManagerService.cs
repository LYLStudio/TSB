using TSB.Models;
using TSB.Services.Logger;

namespace TSB.Services
{
    public interface IManagerService : IPreprocess
    {
    }

    public abstract class ManagerServiceBase : IManagerService
    {
        protected ILogService _logger;

        protected ManagerServiceBase() { }

        protected ManagerServiceBase(ILogService logger) : this()
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger), $"{GetType().FullName}:{nameof(logger)}不得為空值");
        }

        public abstract void Preprocess<T>(IAnything<T> anything);
    }
}
