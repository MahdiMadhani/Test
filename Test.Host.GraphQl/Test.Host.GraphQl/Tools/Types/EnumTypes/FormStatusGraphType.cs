using Domain.Enums;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Host.GraphQl.Tools.Types.EnumTypes
{
    public class FormStatusGraphType : EnumerationGraphType<FormStatus>
    {
        public FormStatusGraphType()
        {
            Name = nameof(FormStatus);

        }
    }
}
