using FluentValidation;

namespace Hope.Application.Validators
{
    public class TagInsertValidator : AbstractValidator<string>
    {
        public TagInsertValidator() 
        {
            RuleFor(x => x).NotEmpty().MaximumLength(60);
        }
    }
}
