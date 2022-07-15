using Domain.GuaranteeItems; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Domain.GuaranteeItems
{
    public class     GuaranteeItemConfiguration : IEntityTypeConfiguration<GuaranteeItem>
    {
        public void Configure(EntityTypeBuilder<GuaranteeItem> builder)
        {
            builder.HasQueryFilter(it => !it.Deleted);

        }
    }
}