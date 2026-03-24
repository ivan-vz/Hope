using Hope.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hope.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(256);
            builder.Property(x => x.Created).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();
        }
    }
}