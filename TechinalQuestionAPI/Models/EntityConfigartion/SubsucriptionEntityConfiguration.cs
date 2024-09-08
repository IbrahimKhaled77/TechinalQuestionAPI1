using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {

        void IEntityTypeConfiguration<Subscription>.Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.SubsucriptionId);
            builder.Property(x=>x.SubsucriptionId).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
