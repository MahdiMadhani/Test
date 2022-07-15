using Domain.Guarantees.Dtos;
using GraphQL.Types;
using Test.Host.GraphQl.Tools.Types.EnumTypes;

namespace Test.Host.GraphQl.Tools.Types.Guarantees
{
    public class GuaranteeSearchType : InputObjectGraphType<GuaranteeSearchDto>
    {
        public GuaranteeSearchType()
        {
            Field(x => x.ClientId, type: typeof(GuidGraphType), nullable: true);
            Field(x => x.ClientName, type: typeof(StringGraphType));
            Field(x => x.Method, type: typeof(GuaranteeMethodEnumGraphType), nullable: true);
            Field(x => x.Date, type: typeof(DateTimeGraphType), nullable: true);
            Field(x => x.InternalNo, type: typeof(StringGraphType));
            Field(x => x.UpdatedDate, type: typeof(DateTimeGraphType), nullable: true);
            Field(x => x.ItemNo, type: typeof(StringGraphType));
            Field(x => x.Amount, type: typeof(DecimalGraphType), nullable: true);
            Field(x => x.IssueDate, type: typeof(DateTimeGraphType), nullable: true);
            Field(x => x.DueDate, type: typeof(DateTimeGraphType), nullable: true);


        }
    }
}