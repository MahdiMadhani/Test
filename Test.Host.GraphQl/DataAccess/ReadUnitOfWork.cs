using DataAccess.Domain.GuaranteeItems;
using DataAccess.Domain.Guarantees;
using DayanaCore.Infrastructure.DataAccess;
using DayanaCore.Infrastructure.DataAccess.Domain;
using Domain;
using Domain.GuaranteeItems;
using Domain.Guarantees;

namespace DataAccess
{
    public class ReadUnitOfWork : BaseReadUnitOfWork, IReadUnitOfWork
    {
        public ReadUnitOfWork(Context context) : base(context)
        {
        }



        private IAuditReadRepository _auditReadRepository;
        public IAuditReadRepository AuditReadRepository
        {
            get
            {
                return _auditReadRepository ??= new AuditReadRepository(DbContext());
            }
        }



        private IGuaranteeReadRepository _guaranteeReadRepository;
        public IGuaranteeReadRepository GuaranteeReadRepository
        {
            get
            {
                return _guaranteeReadRepository ??= new GuaranteeReadRepository(DbContext());
            }
        }

        private IGuaranteeItemReadRepository _guaranteeItemReadRepository;
        public IGuaranteeItemReadRepository GuaranteeItemReadRepository
        {
            get
            {
                return _guaranteeItemReadRepository ??= new GuaranteeItemReadRepository(DbContext());
            }
        }

    }
}
