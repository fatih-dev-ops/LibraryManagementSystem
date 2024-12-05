using AutoMapper;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Dtos;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Services.Interfaces;


namespace LibraryManagementSystem.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public string Add(LoanDto entity)
        {
            var result = _loanRepository.Add(_mapper.Map<Loan>(entity));
            return result;
        }

        public string Delete(int id)
        {
            //Loan silinemez
            return _loanRepository.Delete(id);
        }

        public List<LoanDto> GetAll()
        {
            var loans = _loanRepository.GetAll();
            return loans.Select(l => _mapper.Map<LoanDto>(l)).ToList();
        }

        public List<G> GetAll<G>() where G : class
        {
            throw new NotImplementedException();
        }

        public string Update(LoanDto entity)
        {
            return _loanRepository.Update(_mapper.Map<Loan>(entity));
        }
    }
}
