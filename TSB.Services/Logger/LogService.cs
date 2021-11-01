using System;
using System.IO;

using Newtonsoft.Json;

namespace TSB.Services.Logger
{
    public class LogService : ILogService
    {
        private string _path = string.Empty;

        public LogService(string path)
        {
            _path = path;
        }

        public void Log<T>(T item)
        {
            //todo queue thread

            try
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);

                using (var sw = new StreamWriter(Path.Combine(_path, $"{DateTime.Now:yyyy-MM-dd}.log"), true))
                {
                    var log = JsonConvert.SerializeObject(new { Time = $"{DateTime.Now:O}", Data = item });
#if DEBUG
                    System.Diagnostics.Debug.WriteLine(log);
#endif
                    sw.WriteLine(log);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex);
#endif
            }
        }

        public void Log<T>(T item, Action<T> callback)
        {
            Log(item);

            callback?.Invoke(item);
        }
    }
}
