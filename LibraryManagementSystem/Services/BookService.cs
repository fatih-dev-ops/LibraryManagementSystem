using AutoMapper;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Extensions;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Dtos;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository  _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
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

        public List<BookDetailDto> GetAll()
        {
            var books = _bookRepository.GetAll().Select(b => _mapper.Map<BookDetailDto>(b)).ToList();
            return books;
        }


        public string Update(BookDetailDto bookDto)
        {
            var result = _bookRepository.Update(_mapper.Map<Book>(bookDto));
            return result;
        }


    }
}
