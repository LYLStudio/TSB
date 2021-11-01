using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

//using TSB.Services.CIF.Manager.Models;

namespace TSB.CIF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void Test();

        [OperationContract]
        Services.CIF.Manager.Test.Models.TestRs TestRq(Services.CIF.Manager.Test.Models.TestRq request);

        [OperationContract]
        Services.CIF.Manager.Email.Models.CheckRs CheckRq(Services.CIF.Manager.Email.Models.CheckRq request);
    }
}
