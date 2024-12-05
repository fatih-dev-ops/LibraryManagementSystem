using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface ILoanService : IBaseService<LoanDto>
    {
        public List<LoanDto> GetAll();
    }
}
