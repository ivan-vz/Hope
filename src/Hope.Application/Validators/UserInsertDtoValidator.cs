using FluentValidation;
using Hope.Application.DTOs.Insert;
using Hope.Infrastructure.Interfaces;

namespace Hope.Application.Validators
{
    public class UserInsertDtoValidator : AbstractValidator<UserInsertDto>
    {
        public UserInsertDtoValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(100)
                .EmailAddress()
                .MustAsync( async (email, ct) => !await uow.UserRepository.ExistsByEmailAsync(email, ct)).WithMessage("Invalid Email");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(15)
                .MustAsync(async (number, ct) => !await uow.UserRepository.ExistsByPhoneNumberAsync(number, ct)).WithMessage("Invalid Phone");
            RuleFor(x => x.Address).MaximumLength(256);
        }
    }
}
