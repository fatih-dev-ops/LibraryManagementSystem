using LibraryManagementSystem.Models.Dtos;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet(Name ="GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAll();

            if (books is not null)
            {
                return Ok(books);
            }
            else
                return NotFound(new {Message = "There is no any books."});
        }

        [HttpGet(Name ="GetBook")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetById(id);

            if (book is not null)
            {
                return Ok(book);
            }
            else
                return NotFound(new { Message = $"There is no book for this id = {id}"});
        }

        [HttpGet(Name ="IsAvailableForLoan")]
        public IActionResult IsAvailableForLoan(int bookId)
        {
            var isAvailable = _bookService.IsAvailableForLoan(bookId);
            return Ok(isAvailable);
        }

        [HttpGet(Name ="GetBookLoanHistory")]
        public IActionResult GetBookLoanHistory(int bookId)
        {
            var bookLoans = _bookService.GetLoanHistory(bookId);
            if (bookLoans is null)
            {
                return NotFound(new { Message = "There are no book for this bookId.", BookId = bookId });
            }
            else if(bookLoans.Count == 0)
            {
                return NotFound(new { Message = "There are no any loan for this book.", BookId = bookId });
            }
            else
                return Ok(bookLoans);
        }

        [HttpPost(Name ="AddBook")]
        public IActionResult AddBook([FromBody] BookDetailDto book)
        {
            var result = _bookService.Add(book);
            return Ok(result);
        }
    }
}
