using System;
using Domain.Guarantees.Dtos;
using MediatR;

namespace Application.Guarantees.Queries.Get
{
    public class GuaranteeQuery : IRequest<GuaranteeResponseDto>
    {
        public GuaranteeQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
