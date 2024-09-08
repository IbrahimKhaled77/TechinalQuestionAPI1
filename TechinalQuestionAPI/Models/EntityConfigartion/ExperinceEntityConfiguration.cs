using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class ExperienceEntityConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(x => x.ExperinceId);
            builder.Property(x => x.ExperinceId).UseIdentityColumn();
            builder.Property(x=>x.CompanyName).IsRequired(false);
        }
    }
}
