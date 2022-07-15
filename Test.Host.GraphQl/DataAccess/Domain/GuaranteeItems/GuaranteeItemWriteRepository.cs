using Domain.GuaranteeItems;
using DayanaCore.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Domain.GuaranteeItems
{
    public class   GuaranteeItemWriteRepository : WriteRepository<GuaranteeItem>, IGuaranteeItemWriteRepository
    {
        public   GuaranteeItemWriteRepository(CoreDbContext context) : base(context)
        {
        } 
    }
}