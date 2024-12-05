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
            var loans = _loanService.GetAll();
            var bookLoans = loans.Select(l => l).Where(l => l.Id == bookId).ToList();
            return bookLoans;
        }

        public bool IsAvailableForLoan(int bookId)
        {
            var bookLoans = GetLoanHistory(bookId);
            var notReturnedBooks =  bookLoans?.FirstOrDefault(b => b.State == "Not Returned");
            if (notReturnedBooks is null)
                return true;
            else 
                return false;
        }




    }
}
