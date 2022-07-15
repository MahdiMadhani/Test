using System;
using Test.Host.GraphQl.Tools.Mutations;
using Test.Host.GraphQl.Tools.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Host.GraphQl.Tools.Schemas
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            Mutation = provider.GetRequiredService<AppMutation>();
            Query = provider.GetRequiredService<AppQuery>();
        }
    }
}
