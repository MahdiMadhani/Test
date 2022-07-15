using DataAccess.Domain.GuaranteeItems;
using DataAccess.Domain.Guarantees;
using DayanaCore.Infrastructure.DataAccess;
using DayanaCore.Infrastructure.Messaging;
using Domain;
using Domain.GuaranteeItems;
using Domain.Guarantees;

namespace DataAccess
{
    namespace DataAccess
    {
        public class WriteUnitOfWork : BaseUnitOfWork, IWriteUnitOfWork
        {
            public WriteUnitOfWork(Context context, IPubMessageHandler coreBus) : base(context, coreBus)
            {
            }


            private IGuaranteeWriteRepository _guaranteeWriteRepository;
            public IGuaranteeWriteRepository GuaranteeWriteRepository
            {
                get
                {

                    return _guaranteeWriteRepository ??= new GuaranteeWriteRepository(DbContext());
                }
            }


            private IGuaranteeItemWriteRepository _guaranteeItemWriteRepository;
            public IGuaranteeItemWriteRepository GuaranteeItemWriteRepository
            {
                get
                {
                    return _guaranteeItemWriteRepository ??= new GuaranteeItemWriteRepository(DbContext());
                }
            }

        }
    }
}
