using Domain.Guarantees;
using DayanaCore.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Domain.Guarantees
{
    public class   GuaranteeWriteRepository : WriteRepository<Guarantee>, IGuaranteeWriteRepository
    {
        public   GuaranteeWriteRepository(CoreDbContext context) : base(context)
        {
        } 
    }
}