using Domain.GuaranteeItems;
using DayanaCore.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Domain.GuaranteeItems
{
    public class   GuaranteeItemReadRepository : ReadRepository<GuaranteeItem>, IGuaranteeItemReadRepository
    {
        public   GuaranteeItemReadRepository(CoreDbContext context) : base(context)
        {
        }
    }
}