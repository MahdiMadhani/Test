using Domain.Guarantees;
using DayanaCore.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Domain.Guarantees
{
    public class GuaranteeReadRepository : ReadRepository<Guarantee>, IGuaranteeReadRepository
    {
        public GuaranteeReadRepository(CoreDbContext context) : base(context)
        {
        }
    }
}