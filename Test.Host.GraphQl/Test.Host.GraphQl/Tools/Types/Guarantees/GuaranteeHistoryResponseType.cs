using Domain.Guarantees.Dtos;
using GraphQL.Types;
using Test.Host.GraphQl.Tools.Types.EnumTypes;

namespace Test.Host.GraphQl.Tools.Types.Guarantees
{
    public sealed class GuaranteeHistoryResponseType : ObjectGraphType<GuaranteeHistoryListResponseDto>
    {
        public GuaranteeHistoryResponseType()
        {
            Name = nameof(GuaranteeHistoryListResponseDto);


            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.InternalNo, type: typeof(StringGraphType));
            Field(x => x.Date, type: typeof(DateTimeGraphType));
            Field(x => x.ClientId, type: typeof(GuidGraphType));
            Field(x => x.ClientName, type: typeof(StringGraphType));
            Field(x => x.Method, type: typeof(GuaranteeMethodEnumGraphType));

            Field(x => x.ItemNo, type: typeof(StringGraphType));
            Field(x => x.Amount, type: typeof(DecimalGraphType));


            //Field(x => x.Description, type: typeof(StringGraphType));
            //Field(x => x.ExchangeRate, type: typeof(DecimalGraphType));

            //Field(x => x.AttachmentPath, type: typeof(ListGraphType<StringGraphType>));
        }
    }
}
