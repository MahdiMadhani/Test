using Domain.Guarantees.Dtos;
using Test.Host.GraphQl.Tools.Types.EnumTypes;
using Test.Host.GraphQl.Tools.Types.Guarantees.GuaranteeItems;
using GraphQL.Types;

namespace Test.Host.GraphQl.Tools.Types.Guarantees
{
    public class GuaranteeInputType : InputObjectGraphType<GuaranteeRequestDto>
    {
        public GuaranteeInputType()
        {
            Name = nameof(GuaranteeRequestDto);

            Field(x => x.Id, type: typeof(GuidGraphType));

            Field(x => x.ClientId, type: typeof(GuidGraphType));

            Field(x => x.Method, type: typeof(GuaranteeMethodEnumGraphType));

            Field(x => x.CurrencyId, type: typeof(GuidGraphType));

            Field(x => x.ExchangeRate, type: typeof(DecimalGraphType));

            Field(x => x.Date, type: typeof(DateTimeGraphType));

            Field(x => x.Description, type: typeof(StringGraphType));

            Field(x => x.GuaranteeItemDto, type: typeof(ListGraphType<GuaranteeItemInputType>));
        }
    }
}
