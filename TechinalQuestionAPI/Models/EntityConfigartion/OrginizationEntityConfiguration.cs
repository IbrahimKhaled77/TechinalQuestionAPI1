using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        void IEntityTypeConfiguration<Organization>.Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(x => x.OrganizationId);
            builder.Property(x=>x.OrganizationId).UseIdentityColumn();
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired();
        }
    }
}
