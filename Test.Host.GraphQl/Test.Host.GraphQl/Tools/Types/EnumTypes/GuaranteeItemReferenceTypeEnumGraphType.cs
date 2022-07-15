using Domain.Enums;
using GraphQL.Types;

namespace Test.Host.GraphQl.Tools.Types.EnumTypes
{
    public class GuaranteeItemReferenceTypeEnumGraphType : EnumerationGraphType<GuaranteeItemReferenceTypeEnum>
    {
        public GuaranteeItemReferenceTypeEnumGraphType()
        {
            Name = nameof(GuaranteeItemReferenceTypeEnum);
        }
    }
}
