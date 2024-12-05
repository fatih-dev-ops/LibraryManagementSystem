using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IMemberService : IBaseService<MemberDetailDto>
    {
         public List<MemberListDto> GetAll();
         public MemberDetailDto? GetById(int id);
         public dynamic SetMemberState(MemberDetailDto member);
         public List<LoanDetailDto>? GetLoanHistory(int id);
    }
}
