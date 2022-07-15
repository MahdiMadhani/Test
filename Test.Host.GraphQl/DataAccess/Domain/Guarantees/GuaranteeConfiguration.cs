using Domain.Guarantees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Domain.Guarantees
{
    public class GuaranteeConfiguration : IEntityTypeConfiguration<Guarantee>
    {
        public void Configure(EntityTypeBuilder<Guarantee> builder)
        {
            builder.HasQueryFilter(it => !it.Deleted);

        }
    }
}