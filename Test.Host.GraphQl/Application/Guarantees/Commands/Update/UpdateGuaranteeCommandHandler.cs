using Domain;
using Domain.Enums;
using Domain.GuaranteeItems;
using Domain.Guarantees.Dtos;
using GraphQL;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Guarantees.Commands.Update
{
    public class UpdateGuaranteeCommandHandler : IRequestHandler<UpdateGuaranteeCommand, GuaranteeResponseDto>
    {
        private readonly IWriteUnitOfWork _unitOfWork;
        public UpdateGuaranteeCommandHandler(IWriteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GuaranteeResponseDto> Handle(UpdateGuaranteeCommand request, CancellationToken cancellationToken)
        {
            var requestDto = request.RequestDto;
            var entity = _unitOfWork.GuaranteeWriteRepository.Get(requestDto.Id);

            if (entity == null)
                throw new ExecutionError("Guarantee not found");
            #region entity

            entity.UpdateInstance();

            entity.SetClientId(requestDto.ClientId);

            entity.SetGuaranteeMethod(requestDto.Method);


            entity.SetCurrencyId(requestDto.CurrencyId);

            entity.SetExchangeRate(requestDto.ExchangeRate);

            entity.SetDate(requestDto.Date);

            entity.SetDescription(requestDto.Description);

            _unitOfWork.GuaranteeWriteRepository.UpdateEntity(entity);

            #endregion

            foreach (var guaranteeItem in requestDto.GuaranteeItemDto)
            {
                if (guaranteeItem.Status == FormStatus.Add)
                {
                    var instance = GuaranteeItem.CreateInstance(entity.Id);

                    instance.SetInvesmentId(guaranteeItem.InvesmentId);

                    instance.SetItemNo(guaranteeItem.ItemNo);

                    instance.SetAmount(guaranteeItem.Amount);

                    instance.SetReferenceTypeId(guaranteeItem.ReferenceTypeId);

                    instance.SetReferenceType(guaranteeItem.ReferenceType);

                    instance.SetCurrencyId(guaranteeItem.CurrencyId);

                    instance.SetIssueDate(guaranteeItem.IssueDate);

                    instance.SetDueDate(guaranteeItem.DueDate);
                    
                    await _unitOfWork.GuaranteeItemWriteRepository.AddAsync(instance);

                }

                else if (guaranteeItem.Status == FormStatus.Remove)
                {
                    var GuaranteeItemExist = _unitOfWork.GuaranteeItemWriteRepository.Get(guaranteeItem.Id);
                    if (GuaranteeItemExist != null)
                        _unitOfWork.GuaranteeItemWriteRepository.SoftRemove(GuaranteeItemExist);

                }

                else if (guaranteeItem.Status == FormStatus.Edit)
                {
                    var GuaranteeItemExist = _unitOfWork.GuaranteeItemWriteRepository.Get(guaranteeItem.Id);

                    if (GuaranteeItemExist != null)
                    {
                        GuaranteeItemExist.UpdateInstance();

                        GuaranteeItemExist.SetInvesmentId(guaranteeItem.InvesmentId);

                        GuaranteeItemExist.SetItemNo(guaranteeItem.ItemNo);

                        GuaranteeItemExist.SetAmount(guaranteeItem.Amount);

                        GuaranteeItemExist.SetReferenceTypeId(guaranteeItem.ReferenceTypeId);

                        GuaranteeItemExist.SetReferenceType(guaranteeItem.ReferenceType);

                        GuaranteeItemExist.SetCurrencyId (guaranteeItem.CurrencyId);

                        GuaranteeItemExist.SetIssueDate(guaranteeItem.IssueDate);

                        GuaranteeItemExist.SetDueDate(guaranteeItem.DueDate);

                        _unitOfWork.GuaranteeItemWriteRepository.UpdateEntity(GuaranteeItemExist);
                    }
                }
            }

            await _unitOfWork.Commit(requestDto.SessionKey);

            return new GuaranteeResponseDto
            {
                Id = requestDto.Id,
            };
        }
    }
}
