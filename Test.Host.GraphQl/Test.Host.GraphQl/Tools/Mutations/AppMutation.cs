using Application.Guarantees.Commands.Create;
using Application.Guarantees.Commands.Delete;
using Application.Guarantees.Commands.Update;
using Test.Host.GraphQl.Tools.Types.Guarantees;
using DayanaCore.Infrastructure.Application;
using DayanaCore.Infrastructure.Domain;
using Domain;
using Domain.Guarantees.Dtos;
using GraphQL;
using GraphQL.Types;
using MediatR;
using System;

namespace Test.Host.GraphQl.Tools.Mutations
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IMediator mediator)
        {

            #region Guarantee

            FieldAsync<GuaranteeResponseType>(
               "createGuarantee",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuaranteeInputType>> { Name = nameof(Entity) }),
               resolve: async context =>
               {
                   var requestDto = context.GetArgument<GuaranteeRequestDto>(nameof(Entity));
                   requestDto.SessionKey = context.UserContext.GetSessionKey();

                   return await mediator.Send(new CreateGuaranteeCommand(requestDto));
               });//.RequiredAuthenticatedUser();


            FieldAsync<GuaranteeResponseType>(
              "updateGuarantee",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuaranteeInputType>> { Name = nameof(Entity) }),
              resolve: async context =>
              {
                  var requestDto = context.GetArgument<GuaranteeRequestDto>(nameof(Entity));
                  requestDto.SessionKey = context.UserContext.GetSessionKey();

                  return await mediator.Send(new UpdateGuaranteeCommand(requestDto));
              }).RequiredAuthenticatedUser();

            FieldAsync<GuaranteeResponseType>(
             "deleteGuarantee",
             arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = nameof(Entity) }),
             resolve: async context =>
             {
                 var selectedId = context.GetArgument<Guid>(nameof(Entity));
                 var requestDto = new BaseRequestDto { Id = selectedId, SessionKey = context.UserContext.GetSessionKey() };

                 return await mediator.Send(new DeleteGuaranteeCommand(requestDto));
             }).RequiredAuthenticatedUser();
            #endregion 
        }
    }
}
