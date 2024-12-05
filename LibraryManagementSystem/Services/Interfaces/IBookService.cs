using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IBookService : IBaseService<BookDetailDto>
    {
        public List<BookDetailDto> GetAll();

    }
}
