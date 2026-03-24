using FluentValidation;
using Hope.Application.DTOs.Update;

namespace Hope.Application.Validators
{
    public class OrderUpdateDtoValidator : AbstractValidator<OrderUpdateDto>
    {
        public OrderUpdateDtoValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Meals).Must(x => x.DistinctBy(m => m.Id).Count() == x.Count);
            RuleForEach(x => x.Meals).Must(x => x.Id != Guid.Empty).WithMessage("Id cannot be empty").Must(x => x.Quantity > 0).WithMessage("Quantity must be greater than 0");
        }
    }
}
