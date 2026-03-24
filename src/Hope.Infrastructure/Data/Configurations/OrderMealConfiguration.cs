using Hope.Domain.Models.Auxiliary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hope.Infrastructure.Data.Configurations
{
    public class OrderMealConfiguration : IEntityTypeConfiguration<OrderMeal>
    {
        public void Configure(EntityTypeBuilder<OrderMeal> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.MealId });

            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.Meal).WithMany().HasForeignKey(x => x.MealId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}