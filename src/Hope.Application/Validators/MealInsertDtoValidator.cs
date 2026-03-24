using FluentValidation;
using Hope.Application.DTOs.Insert;
using Hope.Infrastructure.Interfaces;

namespace Hope.Application.Validators
{
    public class MealInsertDtoValidator : AbstractValidator<MealInsertDto>
    {
        public MealInsertDtoValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(60).MustAsync(async (name, ct) => !await uow.MealRepository.ExistsByName(name, ct)).WithMessage("Invalid name");
            RuleFor(x => x.Description).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Price).NotNull().GreaterThanOrEqualTo(0).PrecisionScale(10, 2, false);
        }
    }
}