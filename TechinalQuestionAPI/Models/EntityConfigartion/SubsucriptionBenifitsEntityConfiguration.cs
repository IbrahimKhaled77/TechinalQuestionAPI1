using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class SubscriptionBenefitsEntityConfiguration : IEntityTypeConfiguration<SubscriptionBenefits>
    {

        void IEntityTypeConfiguration<SubscriptionBenefits>.Configure(EntityTypeBuilder<SubscriptionBenefits> builder)
        {
            builder.HasKey(x => x.SubscriptionBenefitId);
            builder.Property(x=>x.SubscriptionBenefitId).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        }
    }
}
