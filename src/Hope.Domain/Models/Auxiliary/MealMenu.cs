namespace Hope.Domain.Models.Auxiliary
{
    public class MealMenu
    {
        public Guid MenuId { get; set; }
        public Guid MealId { get; set; }

        public Menu Menu { get; set; } = null!;
        public Meal Meal { get; set; } = null!;
    }
}
