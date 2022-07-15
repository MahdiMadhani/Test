using DayanaCore.Infrastructure.DataAccess.Domain;
using Domain.GuaranteeItems;
using Domain.Guarantees;

namespace Domain
{
    public interface IWriteUnitOfWork : IBaseUnitOfWork
    {

        IGuaranteeWriteRepository GuaranteeWriteRepository { get; }
        IGuaranteeItemWriteRepository GuaranteeItemWriteRepository { get; }

    }
}
