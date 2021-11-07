namespace TSB.Services.CIF.Manager
{
    using System;

    using TSB.Models;
    using TSB.Services.Logger;

    public partial class Manager : ManagerServiceBase
    {
        public Manager(ILogService logger) : base(logger) { }

        public override void Preprocess<T>(IAnything<T> anything)
        {
            Exception error = null;

            try
            {
                anything?.Callback.Invoke(anything.Parameter);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                var p = (dynamic)anything.Parameter;
                _logger.Log(new { Request = p.RQ, Response = p.RS, Error = error }, (o) =>
                {
                    //customized callback log, db log or something
                    System.Diagnostics.Debug.WriteLine($"something here...{o}");
                });
            }
        }
    }
}
