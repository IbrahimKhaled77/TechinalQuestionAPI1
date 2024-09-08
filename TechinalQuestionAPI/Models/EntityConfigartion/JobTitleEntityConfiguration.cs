using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class JobTitleEntityConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasKey(x => x.JobTitleId);
            builder.Property(x => x.JobTitleId).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(false);
        }
    }
}
