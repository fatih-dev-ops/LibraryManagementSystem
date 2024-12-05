using FluentValidation;
using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Models.Validators
{
    public class LoanDtoValidator : AbstractValidator<LoanDetailDto>
    {
        public LoanDtoValidator()
        {
        }
    }
}
