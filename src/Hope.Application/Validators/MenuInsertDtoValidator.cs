using FluentValidation;
using Hope.Application.DTOs.Insert;
using Hope.Infrastructure.Interfaces;

namespace Hope.Application.Validators
{
    public class MenuInsertDtoValidator : AbstractValidator<MenuInsertDto>
    {
        public MenuInsertDtoValidator(IUnitOfWork uow) 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(60).MustAsync(async (name, ct) => !await uow.MenuRepository.ExistsByName(name, ct)).WithMessage("Invalid Name");
            RuleForEach(x => x.Meals).NotEmpty();
        }
    }
}
