using TSB.Models;

namespace TSB.Services
{
    public interface IPreprocess
    {
        void Preprocess<T>(IAnything<T> anything);
    }
}
