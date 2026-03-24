using FluentValidation;
using Hope.Application.DTOs.Update;

namespace Hope.Application.Validators
{
    public class MealUpdateDtoValidator : AbstractValidator<MealUpdateDto>
    {
        public MealUpdateDtoValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).PrecisionScale(10, 2, false);
        }
    }
}
