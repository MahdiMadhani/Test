using Domain.Guarantees.Dtos;
using MediatR;

namespace Application.Guarantees.Commands.Create
{
    public class CreateGuaranteeCommand : IRequest<GuaranteeResponseDto>
    { 
        public CreateGuaranteeCommand(GuaranteeRequestDto requestDto)
        {
            RequestDto = requestDto;
        }
        public GuaranteeRequestDto RequestDto { get; set; }
    }
}
