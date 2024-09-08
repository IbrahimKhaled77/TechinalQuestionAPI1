using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class SkillsEntityConfiguration : IEntityTypeConfiguration<Skill>
    {

            void IEntityTypeConfiguration<Skill>.Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
           
            builder.HasKey(x => x.SkillsId);
            builder.Property(x => x.SkillsId).UseIdentityColumn().IsRequired();

            builder.Property(x => x.Rate).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
        }
    }
}
