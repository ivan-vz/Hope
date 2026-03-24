using Hope.Application.DTOs.Detail;
using Hope.Domain.Models;

namespace Hope.Application.Extensions
{
    public static class OrderExtensions
    {
        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Total = order.Total,
                Created = order.Created,
                DeliverTo = order.DeliverTo,
                Delivered = order.Delivered,
                User = order.User.ToDto(),
                Meals = [.. order.Meals.Select(x => x.Meal.ToDto())]
            };
        }
    }
}
