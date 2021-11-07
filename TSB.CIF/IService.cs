using System.ServiceModel;

namespace TSB.CIF
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Services.CIF.Manager.Test.Models.TemplateRs TemplateRq(Services.CIF.Manager.Test.Models.TemplateRq request);

        [OperationContract]
        Services.CIF.Manager.Email.Models.QueryContactInfoRs QueryContactInfoRq(Services.CIF.Manager.Email.Models.QueryContactInfoRq request);
    }
}
