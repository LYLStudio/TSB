using TSB.Models.Messages;

namespace TSB.Services.CIF.Manager.Email.Models
{
    public class QueryContactInfoRq : RequestBase
    {
        /*
         * Header.AuthData: { UserID, Token }
         * 
         * Payload.Type:    { TYPE }
         *  TYPE [ EMAIL, CELLPHONE, ALL ]
         */
    }

    public class QueryContactInfoRs : ResponseBase
    {
        /*
         * Payload:
         * Email:     { Value?, Verified?, IsEStatement? }
         * Cellphone: { Value?, Verified? }
         */
    }
}
