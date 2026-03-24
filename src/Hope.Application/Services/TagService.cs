using FluentValidation;
using FluentValidation.Results;
using Hope.Application.Interfaces;
using Hope.Domain.Models;
using Hope.Infrastructure.Interfaces;

namespace Hope.Application.Services
{
    public class TagService(IUnitOfWork uow, IValidator<string> validator) : ITagService
    {
        private readonly IUnitOfWork _unitOfWork = uow;
        private readonly IValidator<string> _validator = validator;

        public async Task<ValidationResult> CreateAsync(string tagName, CancellationToken ct)
        {
            var validation = await _validator.ValidateAsync(tagName, ct);
            if (!validation.IsValid) return validation;

            var tag = await _unitOfWork.TagRepository.ExistsByNameAsync(tagName, ct);
            if (tag is null)
            {
                tag = new Tag(tagName);
                _unitOfWork.TagRepository.Add(tag);
            } else
            {
                tag.IsDeleted = false;
            }

            await _unitOfWork.Complete();

            return validation;
        }

        public async Task<ValidationResult> DeleteAsync(string name, CancellationToken ct)
        {
            var validation = await _validator.ValidateAsync(name, ct);
            if (!validation.IsValid) return validation;

            var tag = await _unitOfWork.TagRepository.GetByNameAsync(name, ct);
            if (tag is null)
            {
                validation.Errors.Add
                    (
                        new ValidationFailure("Tag", "Tag not found")
                    );
            }
            else
            {
                tag.IsDeleted = true;
                await _unitOfWork.Complete();
            }

            return validation;
        }

        public async Task<IReadOnlyList<string>> GetAllAsync(CancellationToken ct) => [..(await _unitOfWork.TagRepository.GetAllTagsAsync(ct)).Select(x => x.Name)];

        public async Task<IReadOnlyList<string>> GetAllActiveAsync(CancellationToken ct) => [.. (await _unitOfWork.TagRepository.GetAllActiveTagsAsync(ct)).Select(x => x.Name)];
    }
}
