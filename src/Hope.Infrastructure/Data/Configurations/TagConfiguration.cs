using Hope.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hope.Infrastructure.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.IsDeleted);
        }
    }
}