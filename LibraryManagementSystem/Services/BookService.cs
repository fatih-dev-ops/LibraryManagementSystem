using AutoMapper;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Dtos;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, ILoanService loanService, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _loanService = loanService;
            _mapper = mapper;
        }

        public string Add(BookDetailDto bookDto)
        {
            var result = _bookRepository.Add(_mapper.Map<Book>(bookDto));
            return result;
        }

        public string Delete(int id)
        {
            var result = _bookRepository.Delete(id);
            return result;
        }

        public List<BookListDto>? GetAll()
        {
            var books = _bookRepository.GetAll()?.Select(b => _mapper.Map<BookListDto>(b)).ToList();
            return books;
        }
        
        public string Update(BookDetailDto bookDto)
        {
            var result = _bookRepository.Update(_mapper.Map<Book>(bookDto));
            return result;
        }
        public BookDetailDto? GetById(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            var bookDetailDto = _mapper.Map<BookDetailDto>(book);
            return bookDetailDto;
        }

        public List<LoanDto>? GetLoanHistory(int bookId)
        {
            var isBookHave = ChechkBook(bookId);
            if (isBookHave)
            {
                var loans = _loanService.GetAll();
                var bookLoans = loans.Select(l => l).Where(l => l.BookId == bookId).ToList();
                return bookLoans;
            }
            else
            {
                return null;
            }

        }

        public string IsAvailableForLoan(int bookId)
        {
            var isBookHave = ChechkBook(bookId);
            if (!isBookHave)
            {
                return $"There is no book for this id :{bookId}.";
            }
            else
            {
                var bookLoans = GetLoanHistory(bookId);
                var notReturnedBooks = bookLoans?.FirstOrDefault(b => b.State == "Not Returned");
                if (notReturnedBooks is null)
                    return "This book is available for loan.";
                else
                    return "This book is not available for loan.";
            }

        }

        private bool ChechkBook(int bookId)
        {
            var isBookHave = GetById(bookId);
            if (isBookHave is null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
