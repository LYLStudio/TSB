using System;

namespace TSB.Services.CIF.Manager.Models
{
    [Flags]
    public enum ContactInfoKind
    {
        NONE,
        EMAIL,
        CELLPHONE,
        ALL = EMAIL | CELLPHONE
    }
}
