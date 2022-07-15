using System.Runtime.Serialization;

namespace Domain.Enums
{
    public enum GuaranteeMethodEnum
    {
        [EnumMember(Value = "BG")]
        BG,

        [EnumMember(Value = "LC")] 
        LC,

        [EnumMember(Value = "PDC")]
        PDC
    }
}