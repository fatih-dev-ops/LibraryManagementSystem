using FluentValidation;
using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Models.Validators
{
    public class MemberDtoValidator : AbstractValidator<MemberDetailDto>
    {
        public MemberDtoValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
