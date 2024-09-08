using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class AnswersEntityConfiguration : IEntityTypeConfiguration<Answers>
    {
        void IEntityTypeConfiguration<Answers>.Configure(EntityTypeBuilder<Answers> builder)
        {
            builder.HasKey(x => x.AnswersId);
            builder.Property(x => x.AnswersId).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.HasCheckConstraint("CHECK_Title", "(len([Title])>(20))");

        }
    }
}
