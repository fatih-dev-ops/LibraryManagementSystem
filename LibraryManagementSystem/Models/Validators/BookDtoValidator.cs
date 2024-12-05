using FluentValidation;
using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Models.Validators
{
    public class BookDtoValidator : AbstractValidator<BookDetailDto>
    {
        public BookDtoValidator() 
        {
            RuleFor(bookDto => bookDto.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(bookDto => bookDto.Name).NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");
            RuleFor(b => b.Description).MaximumLength(250).WithMessage("Description cannot exceed 250 characters");
            RuleFor(b => b.PrintDate).NotEmpty().WithMessage("PrintDate is required");
        }

    }
}

