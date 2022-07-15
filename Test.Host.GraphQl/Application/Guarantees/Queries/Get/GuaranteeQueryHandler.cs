using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;
using Domain.GuaranteeItems.Dtos;
using Domain.Guarantees.Dtos;
using GraphQL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Guarantees.Queries.Get
{
    public class GuaranteeQueryHandler : IRequestHandler<GuaranteeQuery, GuaranteeResponseDto>
    {
        private readonly IReadUnitOfWork _unitOfWork;
        public GuaranteeQueryHandler(IReadUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GuaranteeResponseDto> Handle(GuaranteeQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return null;
            }
            #region


            var result = await (
                from guarantee in _unitOfWork.GuaranteeReadRepository.Get().Where(p => p.Id == request.Id)
               
                select new GuaranteeResponseDto
                {
                    Id = guarantee.Id,
                    ClientId = guarantee.ClientId,
                    ClientName = "",
                    Method = guarantee.Method,
                    CurrencyId = guarantee.CurrencyId,
                    Description = guarantee.Description,
                    ExchangeRate = guarantee.ExchangeRate,
                    Date = guarantee.Date,
                    InternalNo = guarantee.InternalNo,
                    GuaranteeItemDto = new List<GuaranteeItemResponseDto>()
                }).FirstOrDefaultAsync(cancellationToken);

            if (result == null)
                throw new ExecutionError("Entity not found");

            var audit = await (from audit1 in _unitOfWork.AuditReadRepository.Get()
                    .Where(a => a.ReferenceId == result.Id.ToString())
                                
                               orderby audit1.DateTime descending
                               select new
                               {
                                   audit1.UserId,
                                    
                                   ModifiedDate = audit1.DateTime
                               }).FirstOrDefaultAsync(cancellationToken);
            if (audit != null)
            {
                result.UserId = audit.UserId;
                result.FullName = "";
                result.UserName = "";
                result.Email = "";
                result.ModifiedDate = audit.ModifiedDate;
            }


            var guaranteeItem = await (
                  from item in _unitOfWork.GuaranteeItemReadRepository.Get().Where(p => p.GuaranteeId == request.Id)
                   
                  select new GuaranteeItemResponseDto
                  {
                      Id = item.Id,
                      InvesmentId = item.InvesmentId != Guid.Empty ? item.InvesmentId : null,
                      ItemNo = item.ItemNo,
                      Amount = item.Amount * result.ExchangeRate,
                      ReferenceType = item.ReferenceType,
                      ReferenceTypeNo = "",
                      ReferenceTypeId = item.ReferenceTypeId,
                      CurrencyId = item.CurrencyId,
                      DueDate = item.DueDate,
                      IssueDate = item.IssueDate,
                  }).ToListAsync(cancellationToken);


            foreach (var item in guaranteeItem)
            {
                item.ReferenceTypeNo = GetReferenceTypeNo(item.ReferenceTypeId, item.ReferenceType);

            }

            if (guaranteeItem.Count > 0)
                result.GuaranteeItemDto.AddRange(guaranteeItem);

            return result;
            #endregion

        }
        private string GetReferenceTypeNo(Guid? referenceTypeId, GuaranteeItemReferenceTypeEnum? referenceType)
        {

            switch (referenceType)
            {

                case GuaranteeItemReferenceTypeEnum.PROFORMA:
                    return "";

                case GuaranteeItemReferenceTypeEnum.TRADECONTRACT:
                    return "";

                case GuaranteeItemReferenceTypeEnum.VOYAGECHARTER:
                    return "";

                case GuaranteeItemReferenceTypeEnum.TIMECHARTER:
                    return "";

            }
            return "";
        }
    }
}
