namespace TSB.CIF
{
    public class Service : IService
    {
        public Services.CIF.Manager.Test.Models.TemplateRs TemplateRq(Services.CIF.Manager.Test.Models.TemplateRq request)
        {
            return new Services.CIF.Manager.Manager(Global.Logger).TemplateRq(request);
        }

        public Services.CIF.Manager.Email.Models.QueryContactInfoRs QueryContactInfoRq(Services.CIF.Manager.Email.Models.QueryContactInfoRq request)
        {
            return new Services.CIF.Manager.Manager(Global.Logger).QueryContactInfoRq(request);
        }
    }
}
