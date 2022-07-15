﻿using Domain.GuaranteeItems.Dtos;
using GraphQL.Types;
using Test.Host.GraphQl.Tools.Types.EnumTypes;

namespace Test.Host.GraphQl.Tools.Types.Guarantees.GuaranteeItems
{
    public class GuaranteeItemResponseType : ObjectGraphType<GuaranteeItemResponseDto>
    {
        public GuaranteeItemResponseType()
        {
            Name = nameof(GuaranteeItemResponseDto);

            Field(x => x.Id, type: typeof(GuidGraphType));

            Field(x => x.InvesmentId, type: typeof(GuidGraphType), nullable: true);

            Field(x => x.ItemNo, type: typeof(StringGraphType));

            Field(x => x.Amount, type: typeof(DecimalGraphType));

            Field(x => x.ReferenceTypeId, type: typeof(GuidGraphType), nullable: true);

            Field(x => x.ReferenceType, type: typeof(GuaranteeItemReferenceTypeEnumGraphType), nullable: true);

            Field(x => x.ReferenceTypeNo, type: typeof(StringGraphType), nullable: true);

            Field(x => x.CurrencyId, type: typeof(GuidGraphType));

            Field(x => x.CurrencyName, type: typeof(StringGraphType));

            Field(x => x.IssueDate, type: typeof(DateTimeGraphType));

            Field(x => x.DueDate, type: typeof(DateTimeGraphType));

            Field<FormStatusGraphType>(nameof(GuaranteeItemRequestDto.Status));


        }
    }
}