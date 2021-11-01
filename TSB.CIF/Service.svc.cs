using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using TSB.Models.Messages;

using System.Dynamic;

namespace TSB.CIF
{
    public class Service : IService
    {        
        public void Test()
        {
            var rq = new Services.CIF.Manager.Test.Models.TestRq();

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

            dynamic p = new ExpandoObject();
            p.AcctID  = "1010020210004150";
            p.Balance = 9001.12M ;
            p.Amt     = 1.12M ;
            rq.Payload = p;

            var rs = new Services.CIF.Manager.Manager(Global.Logger).TestRq(rq);

        }

        public Services.CIF.Manager.Test.Models.TestRs TestRq(Services.CIF.Manager.Test.Models.TestRq request)
        {
            return new Services.CIF.Manager.Manager(Global.Logger).TestRq(request);
        }

        public Services.CIF.Manager.Email.Models.CheckRs CheckRq(Services.CIF.Manager.Email.Models.CheckRq request)
        {
            return new Services.CIF.Manager.Manager(Global.Logger).CheckRq(request);
        }
    }
}
