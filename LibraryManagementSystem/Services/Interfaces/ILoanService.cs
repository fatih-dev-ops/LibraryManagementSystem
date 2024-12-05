using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface ILoanService : IBaseService<LoanDetailDto>
    {
        public string? SetLoanState(LoanStateDto loanStateDto);
        public List<LoanDetailDto> GetAll();
    }
}
