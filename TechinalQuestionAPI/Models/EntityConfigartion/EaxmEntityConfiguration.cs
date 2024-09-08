using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{

    public class ExamEntityConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {

            builder.HasKey(x => x.ExamId);
            builder.Property(x=>x.ExamId).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.QuestionCount).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.NationalityId).IsRequired().HasMaxLength(10); ;
            builder.Property(x => x.level).HasMaxLength(100);
            builder.Property(x => x.Mark).IsRequired().HasDefaultValue(0).HasMaxLength(100);
         //   builder.HasCheckConstraint("Check_Title","(Len(Title>=5))");
         //   builder.HasCheckConstraint("Check_Question_Count","(QuestionCount>=0)");
         //builder.HasCheckConstraint("Check_Duration", "(Duration>0)");
         //   builder.HasCheckConstraint("Check_NationalityId","(Len(NationalityId)=10)");
          //  builder.HasCheckConstraint("Check_Mark", "(Mark>0)");




        }
    }
}
