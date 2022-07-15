using Domain;
using Domain.Guarantees.Dtos;
using MediatR;

namespace Application.Guarantees.Commands.Delete
{ 
    public class DeleteGuaranteeCommand : IRequest<GuaranteeResponseDto>
    {
        public DeleteGuaranteeCommand(BaseRequestDto requestDto)
        {
            RequestDto = requestDto;
        }
        public BaseRequestDto RequestDto { get; set; }
    }
}
