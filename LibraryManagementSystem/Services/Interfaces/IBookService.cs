using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IBookService : IBaseService<BookDetailDto>
    {
        public List<BookListDto>? GetAll();
        public BookDetailDto? GetById(int bookId);
        public List<LoanDetailDto>? GetLoanHistory(int bookId);
        public string  IsAvailableForLoan(int bookId);

    }
}
