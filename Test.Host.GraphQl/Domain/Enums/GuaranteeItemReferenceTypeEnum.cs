using System.Runtime.Serialization;

namespace Domain.Enums
{
    public enum GuaranteeItemReferenceTypeEnum
    {
        [EnumMember(Value = "Proforma")]
        PROFORMA,

        [EnumMember(Value = "TradeContract")]
        TRADECONTRACT,

        [EnumMember(Value = "VoyageCharter")]
        VOYAGECHARTER,

        [EnumMember(Value = "TimeCharter")]
        TIMECHARTER,

    }
}