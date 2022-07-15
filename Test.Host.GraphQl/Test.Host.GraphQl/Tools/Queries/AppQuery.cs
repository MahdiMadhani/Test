using Application.Guarantees.Queries.Get;
using Application.Guarantees.Queries.History;
using Test.Host.GraphQl.Tools.Types.Guarantees;
using DayanaCore.Infrastructure.Application;
using DayanaCore.Infrastructure.Domain;
using Domain.Guarantees.Dtos;
using GraphQL;
using GraphQL.Types;
using MediatR;
using System;

namespace Test.Host.GraphQl.Tools.Queries
{
    public class AppQuery : ObjectGraphType
    {
        public class PagedCollectionType<T, TDto> : ObjectGraphType<PagedCollection<TDto>>
            where T : IGraphType
        {
            public PagedCollectionType()
            {
                Name = $"PagedCollection_{typeof(T).Name}";
                Field<ListGraphType<T>>("value");
                Field<IntGraphType>("offset");
                Field<IntGraphType>("limit");
                Field<IntGraphType>("size");
                Field<ListGraphType<StringGraphType>>("routeValues");
            }
        }
        public class PaginationType : InputObjectGraphType
        {
            public PaginationType()
            {
                Name = nameof(PaginationType);
                Field<IntGraphType>("offset");
                Field<IntGraphType>("limit");
            }
        }

        public AppQuery(IMediator mediator)
        {
            #region Guarantee

            FieldAsync<PagedCollectionType<GuaranteeHistoryResponseType, GuaranteeHistoryListResponseDto>>(
               "Guarantees",
               arguments: new QueryArguments(new QueryArgument<PaginationType> { Name = nameof(PaginationType) }
                   , new QueryArgument<GuaranteeSearchType> { Name = "SearchType" }),
               resolve: async context =>
               {
                   var pagination = context.GetArgument<Pagination>(nameof(PaginationType));

                   var searchTerm = context.GetArgument<GuaranteeSearchDto>("SearchType");

                   return await mediator.Send(new GuaranteeHistoryQuery(pagination, searchTerm));
               }).RequiredAuthenticatedUser();

            FieldAsync<GuaranteeResponseType>(
            "getGuarantee",
            arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = nameof(Entity) }),
            resolve: async context =>
            {
                var selectedId = context.GetArgument<Guid>(nameof(Entity));

                return await mediator.Send(new GuaranteeQuery(selectedId));

            }).RequiredAuthenticatedUser();

             
            #endregion


        }


    }
}
