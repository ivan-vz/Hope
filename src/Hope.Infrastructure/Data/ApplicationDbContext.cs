using Hope.Domain.Models;
using Hope.Domain.Models.Auxiliary;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<OrderMeal> OrdersMeals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Meal>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Menu>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Order>().HasQueryFilter(x => x.IsCancelled == false);
            modelBuilder.Entity<MealMenu>().HasQueryFilter(x => !x.Meal.IsDeleted && !x.Menu.IsDeleted);
            modelBuilder.Entity<MealTag>().HasQueryFilter(x => !x.Meal.IsDeleted && !x.Tag.IsDeleted);
            modelBuilder.Entity<OrderMeal>().HasQueryFilter(x => !x.Meal.IsDeleted && !x.Order.IsCancelled);
        }
    }
}
