using Domain;
using Domain.Guarantees.Dtos;
using DayanaCore.Infrastructure.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Guarantees.Queries.History
{
    public class GuaranteeHistoryQueryHandler : IRequestHandler<GuaranteeHistoryQuery, PagedCollection<GuaranteeHistoryListResponseDto>>
    {
        private readonly IReadUnitOfWork _unitOfWork;
        public GuaranteeHistoryQueryHandler(IReadUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedCollection<GuaranteeHistoryListResponseDto>> Handle(GuaranteeHistoryQuery request, CancellationToken cancellationToken)
        {
            var result = (from guarantee in _unitOfWork.GuaranteeReadRepository.Get()

                          select new GuaranteeHistoryListResponseDto
                          {
                              Id = guarantee.Id,
                              InternalNo = guarantee.InternalNo,
                              Date = guarantee.Date,
                              ClientId = guarantee.ClientId,
                              Method = guarantee.Method,
                              Amount = guarantee.GuaranteeItems.Sum(x => x.Amount) * guarantee.ExchangeRate,
                              ItemNo = guarantee.GuaranteeItems.Select(x => x.ItemNo).FirstOrDefault(),
                              UpdatedDate = guarantee.UpdatedDate
                          });


            var processor = new SearchOptionsProcessor<GuaranteeSearchDto, GuaranteeHistoryListResponseDto>(request.GuaranteeSearch);

            result = processor.Apply(result).OrderByDescending(a => a.UpdatedDate);

            var size = await result.CountAsync(cancellationToken: cancellationToken);

            result = result.Skip(request.Pagination.Offset ?? 0).Take(request.Pagination.Limit ?? 10);

            return PagedCollection<GuaranteeHistoryListResponseDto>.Create(await result.ToListAsync(cancellationToken: cancellationToken), size, new PagingOption { Limit = request.Pagination.Limit, Offset = request.Pagination.Offset });
        }

    }
}
