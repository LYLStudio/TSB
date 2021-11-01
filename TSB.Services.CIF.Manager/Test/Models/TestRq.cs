using TSB.Models.Messages;

namespace TSB.Services.CIF.Manager.Test.Models
{
    public class TestRq : RequestBase
    {
        /*
         * Payload Spec
         * AcctID   string(19)
         * Balance  decimal(13,2)
         * Amt      decimal(13,2)
         * 
         */
    }

    public class TestRs : ResponseBase
    {
        /*
         * TestData     string
         * Balance      decimail(13,2)
         * PostedDate   string(10)      format(yyyy-MM-dd)
         * 
         */
    }
}
