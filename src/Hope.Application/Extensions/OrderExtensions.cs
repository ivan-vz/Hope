using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Records;
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
                Address = order.Address,
                Message = order.Message,
                User = order.User.ToDto(),
                Meals = [.. order.Meals.Select(x => x.Meal.ToDto())]
            };
        }

        public static OrderForUpdateDto ToUpdateDto(this Order order, string officeAddress)
        {
            return new OrderForUpdateDto
            {
                Delivery = order.Address != officeAddress,
                Address = (order.Address != officeAddress) ? order.Address : null,
                Message = (order.Address != officeAddress) ? order.Message : null,
                Meals = [.. order.Meals.Select(x => new MealItem(x.MealId, x.Quantity))]
            };
        }
    }
}
