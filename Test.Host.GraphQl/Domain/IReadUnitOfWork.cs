using DayanaCore.Infrastructure.DataAccess.Domain;
using Domain.GuaranteeItems;
using Domain.Guarantees;

namespace Domain
{
    public interface IReadUnitOfWork : IBaseReadUnitOfWork
    {
         IAuditReadRepository AuditReadRepository { get; }

        IGuaranteeReadRepository GuaranteeReadRepository { get; }
        IGuaranteeItemReadRepository GuaranteeItemReadRepository { get; }


    }
}