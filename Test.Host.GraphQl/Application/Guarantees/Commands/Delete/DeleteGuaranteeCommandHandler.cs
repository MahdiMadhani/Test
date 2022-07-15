using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Guarantees.Dtos;
using GraphQL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Guarantees.Commands.Delete
{
    public class DeleteGuaranteeCommandHandler : IRequestHandler<DeleteGuaranteeCommand, GuaranteeResponseDto>
    {
        private readonly IWriteUnitOfWork _unitOfWork;
        public DeleteGuaranteeCommandHandler(IWriteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GuaranteeResponseDto> Handle(DeleteGuaranteeCommand request, CancellationToken cancellationToken)
        {

            if (request.RequestDto.Id == Guid.Empty)
            {
                return null;
            }

            var selectedId = request.RequestDto.Id;

            var entity = await _unitOfWork.GuaranteeWriteRepository.Find(a => a.Id == selectedId).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new ExecutionError("Guarantee not found");

            var guaranteeItems = await _unitOfWork.GuaranteeItemWriteRepository.Find(a => a.GuaranteeId == entity.Id).ToListAsync(cancellationToken);

            _unitOfWork.GuaranteeItemWriteRepository.SoftRemoveRangeEntities(guaranteeItems);

            _unitOfWork.GuaranteeWriteRepository.SoftRemove(entity);

            await _unitOfWork.Commit(request.RequestDto.SessionKey);

            return new GuaranteeResponseDto
            {
                Id = entity.Id
            };
        }
    }
}
