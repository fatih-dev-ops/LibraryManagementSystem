﻿using AutoMapper;
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

        public string Add(LoanDetailDto entity)
        {
            var result = _loanRepository.Add(_mapper.Map<Loan>(entity));
            return result;
        }

        public string Delete(int id)
        {
            //Loan silinemez
            return _loanRepository.Delete(id);
        }

        public List<LoanDetailDto> GetAll()
        {
            var loans = _loanRepository.GetAll();
            return loans.Select(l => _mapper.Map<LoanDetailDto>(l)).ToList();
        }
        public string? SetLoanState(LoanStateDto loanStateDto)
        {
            var loans = GetAll();
            var matchedLoan = loans.FirstOrDefault(l => l.Id == loanStateDto.Id && l.ReturnedDate ==null && l.State == "Not Returned" );
            if (matchedLoan is not null)
            {
                matchedLoan.ReturnedDate = loanStateDto.ReturnedDate;
                matchedLoan.State = loanStateDto.State; 
                var result = Update(matchedLoan);
                return result;
            }
            else
            {
                return $"Lütfen geçerli bir giriniz. Güncellemek istediğiniz loan state'i {matchedLoan?.State}";
            }
        }
        public string Update(LoanDetailDto entity)
        {
            return _loanRepository.Update(_mapper.Map<Loan>(entity));
        }
    }
}
