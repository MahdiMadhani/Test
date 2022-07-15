using Domain.Guarantees.Dtos;
using Test.Host.GraphQl.Tools.Types.EnumTypes;
using Test.Host.GraphQl.Tools.Types.Guarantees.GuaranteeItems;
using GraphQL.Types;

namespace Test.Host.GraphQl.Tools.Types.Guarantees
{
    public class GuaranteeResponseType : ObjectGraphType<GuaranteeResponseDto>
    {
        public GuaranteeResponseType()
        {
            Name = nameof(GuaranteeResponseDto);
            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.InternalNo, type: typeof(StringGraphType));
            Field(x => x.ClientId, type: typeof(GuidGraphType));
            Field(x => x.ClientName, type: typeof(StringGraphType));
            Field(x => x.CurrencyId, type: typeof(GuidGraphType));
            Field(x => x.ExchangeRate, type: typeof(DecimalGraphType));
            Field(x => x.Method, type: typeof(GuaranteeMethodEnumGraphType));
            Field(x => x.Date, type: typeof(DateTimeGraphType));
            Field(x => x.Description, type: typeof(StringGraphType));
            Field(x => x.GuaranteeItemDto, type: typeof(ListGraphType<GuaranteeItemResponseType>));
            Field(x => x.UserId, type: typeof(StringGraphType)).Description("...");
            Field(x => x.FullName, type: typeof(StringGraphType)).Description("...");
            Field(x => x.UserName, type: typeof(StringGraphType)).Description("...");
            Field(x => x.Email, type: typeof(StringGraphType)).Description("...");
            Field(x => x.ModifiedDate, type: typeof(DateTimeGraphType)).Description("...");
        }
    }
}