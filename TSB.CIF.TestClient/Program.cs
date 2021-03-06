using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TSB.CIF.TestClient.CIFManager;

namespace TSB.CIF.TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var rq = new TestRq();

            rq.Header = new RequestHeader()
            {
                BatchID = $"{Guid.NewGuid()}",
                //Action = nameof(TestExpandoRq),
                Action = rq.GetType().Name,
                MsgID = $"{rq.GetType().Name}_{DateTime.Now:yyyyMMddHHmmssffff}",
                FrnName = "HOME",
                ClientIP = "127.0.0.1",
                ServerIP = "128.0.0.1",
                RequestTime = DateTime.Now,
                UserID = "A123456789"
            };
            rq.Payload = new Dictionary<string, object>()
            {
                { "AcctID", "1010020210004150" },
                { "Balance", 9001.12M },
                { "Amt", 1.12M }
            };

            using (var svc = new ServiceClient())
            {
                await svc.TestRqAsync(rq);
                await svc.CheckRqAsync(new CheckRq());
            }
        }
    }
}
