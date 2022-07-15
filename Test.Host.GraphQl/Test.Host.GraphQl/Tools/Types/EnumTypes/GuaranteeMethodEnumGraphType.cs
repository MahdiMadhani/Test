using Domain.Enums;
using GraphQL.Types;

namespace Test.Host.GraphQl.Tools.Types.EnumTypes
{
    public class GuaranteeMethodEnumGraphType : EnumerationGraphType<GuaranteeMethodEnum>
    {
        public GuaranteeMethodEnumGraphType()
        {
            Name = nameof(GuaranteeMethodEnum);
        }
    }
}
