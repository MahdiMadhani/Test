using Domain.Guarantees.Dtos;
using DayanaCore.Infrastructure.Domain;
using MediatR;

namespace Application.Guarantees.Queries.History
{
    public class GuaranteeHistoryQuery : IRequest<PagedCollection<GuaranteeHistoryListResponseDto>>
    {

        public GuaranteeHistoryQuery(Pagination pagination, GuaranteeSearchDto guaranteeSearch)
        {
            Pagination = pagination;
            GuaranteeSearch = guaranteeSearch;
        }
        public Pagination Pagination { get; set; }
        public GuaranteeSearchDto GuaranteeSearch { get; set; }
    }
}
