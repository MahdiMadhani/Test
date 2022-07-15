using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;
using Domain.GuaranteeItems;
using Domain.Guarantees;
using Domain.Guarantees.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Guarantees.Commands.Create
{
    public class CreateGuaranteeCommandHandler : IRequestHandler<CreateGuaranteeCommand, GuaranteeResponseDto>
    {
        private readonly IWriteUnitOfWork _unitOfWork;
        public CreateGuaranteeCommandHandler(IWriteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GuaranteeResponseDto> Handle(CreateGuaranteeCommand request, CancellationToken cancellationToken)
        {
            var requestDto = request.RequestDto;

            var entity = Guarantee.CreateInstance();

            var middleOfCoNum = $"RP-G{DateTime.Today.Year}{DateTime.Today.Month:d2}-";

            var numberCounter = (await _unitOfWork.GuaranteeWriteRepository.Find(m => true).IgnoreQueryFilters().CountAsync(cancellationToken)).NumberCounter();

            var coNumber = $"{middleOfCoNum}{numberCounter}";

            entity.SetInternalNo(coNumber);

            entity.SetClientId(requestDto.ClientId);

            entity.SetGuaranteeMethod(requestDto.Method);

            entity.SetCurrencyId(requestDto.CurrencyId);

            entity.SetExchangeRate(requestDto.ExchangeRate);

            entity.SetDate(requestDto.Date);

            entity.SetDescription(requestDto.Description);

            await _unitOfWork.GuaranteeWriteRepository.AddAsync(entity);

            foreach (var item in requestDto.GuaranteeItemDto)
            {
                if (item.Status == FormStatus.Remove)
                    continue;

                var instance = GuaranteeItem.CreateInstance(entity.Id);

                instance.SetInvesmentId(item.InvesmentId);

                instance.SetItemNo(item.ItemNo);

                instance.SetAmount(item.Amount);

                instance.SetReferenceTypeId(item.ReferenceTypeId);

                instance.SetReferenceType(item.ReferenceType);

                instance.SetCurrencyId(item.CurrencyId);

                instance.SetIssueDate(item.IssueDate);

                instance.SetDueDate(item.DueDate);


                await _unitOfWork.GuaranteeItemWriteRepository.AddAsync(instance);
            }

            await _unitOfWork.Commit(requestDto.SessionKey);

            return new GuaranteeResponseDto
            {
                Id = entity.Id
            };
        }
    }
}
