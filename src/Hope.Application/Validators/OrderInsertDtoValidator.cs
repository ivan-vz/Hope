using FluentValidation;
using Hope.Application.DTOs.Insert;

namespace Hope.Application.Validators
{
    public class OrderInsertDtoValidator : AbstractValidator<OrderInsertDto>
    {
        public OrderInsertDtoValidator() 
        {
            RuleFor(x => x.Meals).Must(x => x.DistinctBy(m => m.Id).Count() == x.Count);
            RuleForEach(x => x.Meals).Must(x => x.Id != Guid.Empty).WithMessage("Id cannot be empty").Must(x => x.Quantity > 0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.To).GreaterThanOrEqualTo(_ => DateOnly.FromDateTime(DateTime.UtcNow).AddDays(2)).WithMessage("The date must be at least two days from today");
            RuleFor(x => x.Address).NotEmpty().When(x => x.Delivery);
            RuleFor(x => x.Address).Empty().When(x => !x.Delivery);
            // _ => ... al ser un lambda se ejecuta cada vez, por lo que utcnow siempre va a estar actualizado
        }
    }
}
