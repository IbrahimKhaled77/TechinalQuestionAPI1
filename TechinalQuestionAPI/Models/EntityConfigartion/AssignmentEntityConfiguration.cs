using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class AssignmentEntityConfiguration : IEntityTypeConfiguration<Assignment>
    {

        void IEntityTypeConfiguration<Assignment>.Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(x => x.AssignmentId);
            builder.Property(x=>x.AssignmentId).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
        }
    }
}
