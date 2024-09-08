using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{

    public class EducationHistoryEntityConfiguration : IEntityTypeConfiguration<EducationHistory>

    {
        public void Configure(EntityTypeBuilder<EducationHistory> builder)
        {

            builder.HasKey(x => x.EducationHistoryId);
            builder.Property(x=>x.EducationHistoryId).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            //builder.HasCheckConstraint("TitleCheck", "(len([Title])>(10)");
            builder.Property(x => x.Description).IsRequired();
            //builder.HasCheckConstraint("DescriptionCheck", "(len([Description])>(15)AND(len([Description])<(50)");
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.NationalityId).IsRequired();
            //builder.HasCheckConstraint("NationalityCheck", "(len([NationalityId])=(10))");

           



        }
    }
}
