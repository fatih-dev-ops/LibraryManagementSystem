using FluentValidation;
using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Models.Validators
{
    public class LoanDtoValidator : AbstractValidator<LoanDto>
    {
        public LoanDtoValidator()
        {
        }
    }
}
