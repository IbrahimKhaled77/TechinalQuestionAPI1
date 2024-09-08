using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalQuestionAPI.Models.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.NationlityId);
            builder.HasKey(x=>x.UserId);
            builder.Property(x => x.UserId).UseIdentityColumn();
            builder.Property(x=>x.NationlityId).IsRequired();
            builder.Property(x => x.NationlityId).HasMaxLength(10);
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x=>x.UserType).IsRequired();
            builder.Property(x=>x.PersonalPhotoPath).IsRequired(false);
            builder.Property(x=>x.PhoneNumber).HasMaxLength(13);
            //builder.Property(x => x.Organization).IsRequired(false);
            
        }
    }
}
