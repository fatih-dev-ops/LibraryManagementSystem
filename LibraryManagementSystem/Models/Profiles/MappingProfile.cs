using AutoMapper;
using LibraryManagementSystem.Models.Dtos;

namespace LibraryManagementSystem.Models.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDetailDto>().ReverseMap();
            CreateMap<Book, BookListDto>().ReverseMap();
            CreateMap<Member, MemberDetailDto>().ReverseMap();
            CreateMap<Member, MemberListDto>().ReverseMap();
            CreateMap<Library, LibraryDto>().ReverseMap();
            CreateMap<Loan, LoanDetailDto>().ReverseMap();
        }
    }
}
