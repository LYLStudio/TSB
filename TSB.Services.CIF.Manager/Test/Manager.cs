namespace TSB.Services.CIF.Manager
{
    using System;
    using System.Dynamic;

    using Models;

    using TSB.Models.Messages;
    using TSB.Services.CIF.Manager.Test.Models;

    using StatusCode = Test.Models.StatusCode;

    public partial class Manager : ManagerServiceBase
    {
        public TestRs TestRq(TestRq rq)
        {
            var rs = new TestRs()
            {
                Header = new ResponseHeader()
                {
                    MsgID = rq.Header.MsgID,
                    Message = string.Empty,
                    ProcessIP = "127.0.0.2",
                    StatusCode = string.Empty
                },
                Payload = new ExpandoObject()
            };

            Preprocess(new AnythingDynamic()
            {
                Parameter = new { RQ = rq, RS = rs },
                Callback = o =>
                {
                    try
                    {
                        //TODO

                        o.RS.Payload.TestData = $"{nameof(TestRq)}: TEST DATA";
                        o.RS.Payload.Balance = o.RQ.Payload.Balance - o.RQ.Payload.Amt;
                        o.RS.Payload.PostedDate = $"{DateTime.Now:yyyy-MM-dd}";

                        o.RS.Header.StatusCode = StatusCode.SUCCESS;
                        o.RS.Header.Message = "TestOK";
                        o.RS.Header.ResponseTime = DateTime.Now;
                        o.RS.Header.IsOK = true;
                    }
                    catch (Exception ex)
                    {
                        o.RS.Header.StatusCode = StatusCode.ERROR_GENERIC;
                        o.RS.Header.Message = string.IsNullOrWhiteSpace(o.RS.Header.Message) ? $"{ex.Message}" : string.Join("|", $"{o.RS.Header.Message}", $"{ex.Message}");
                        o.RS.Header.ResponseTime = DateTime.Now;
                        throw;
                    }
                }
            });

            return rs;
        }
    }
}
