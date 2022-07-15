using Domain.Guarantees.Dtos;
using MediatR;

namespace Application.Guarantees.Commands.Update
{
    public class UpdateGuaranteeCommand : IRequest<GuaranteeResponseDto>
    {
        public UpdateGuaranteeCommand(GuaranteeRequestDto requestDto)
        { 
            RequestDto = requestDto;
        }
        public GuaranteeRequestDto RequestDto { get; set; }
    }
}
