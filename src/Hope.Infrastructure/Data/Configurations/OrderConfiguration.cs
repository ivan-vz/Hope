using Hope.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hope.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Total).HasPrecision(10, 2).IsRequired();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.DeliverTo).HasMaxLength(200);
            builder.Property(x => x.Delivered);
            builder.Property(x => x.To).IsRequired();
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.IsCancelled).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Meals).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.To);
            builder.HasIndex(x => x.IsCancelled);
        }
    }
}
