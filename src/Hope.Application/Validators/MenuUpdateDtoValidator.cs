using FluentValidation;
using Hope.Application.DTOs.Update;

namespace Hope.Application.Validators
{
    public class MenuUpdateDtoValidator : AbstractValidator<MenuUpdateDto>
    {
        public MenuUpdateDtoValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleForEach(x => x.Meals).NotEmpty();
            RuleFor(x => x.AvailableMonths).Must(x => x.Distinct().Count() == x.Count);
            RuleForEach(x => x.AvailableMonths).Must(date => date >= DateOnly.FromDateTime(DateTime.UtcNow)).WithMessage("You cannot set a date in the past");
        }
    }
}
