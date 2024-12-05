using AutoMapper;
using LibraryManagementSystem.Models.Dtos;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Services.Interfaces;
using Member = LibraryManagementSystem.Models.Member;

namespace LibraryManagementSystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, ILoanService loanService, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _loanService = loanService;
            _mapper = mapper;
        }

        public string Add(MemberDetailDto entity)
        {
            return _memberRepository.Add(_mapper.Map<Member>(entity)); ;
        }

        public string Delete(int id)
        {
            return _memberRepository.Delete(id);
        }



        public List<MemberListDto> GetAll()
        {
            var members = _memberRepository.GetAll();
            return members.Select(member => _mapper.Map<MemberListDto>(member)).ToList();


        }

        public MemberDetailDto? GetById(int id)
        {
            var member = _memberRepository.GetById(id);
            if (member == null)
            {
                return null;
            }
            else return _mapper.Map<MemberDetailDto>(member);
        }

        public List<LoanDto>? GetLoanHistory(int id)
        {
            var loans = _loanService.GetAll();
            var memberLoans = loans.Select(l => l).Where(l => l.MemberId == id).ToList();
            return memberLoans;
        }

        public dynamic SetMemberState(MemberDetailDto member)
        {
            var matchedMember = GetById(member.Id);
            if (matchedMember == null)
            {
                return "Member not found.";
            }
            else
            {
                if (member.State == matchedMember.State)
                {
                    return false;
                }

                else
                {
                    var result = _memberRepository.Update(_mapper.Map<Member>(member));
                    return result;
                }
            }
        }

        public string Update(MemberDetailDto entity)
        {
            return _memberRepository.Update(_mapper.Map<Member>(entity));
        }


    }
}
