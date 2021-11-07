using TSB.Models.Messages;

namespace TSB.Services.CIF.Manager.Test.Models
{
    public class TemplateRq : RequestBase
    {
        /*
         * Payload Spec
         * AcctID   string(19)
         * Balance  decimal(13,2)
         * Amt      decimal(13,2)
         * 
         */
    }

    public class TemplateRs : ResponseBase
    {
        /*
         * TestData     string
         * Balance      decimail(13,2)
         * PostedDate   string(10)      format(yyyy-MM-dd)
         * 
         */
    }
}
