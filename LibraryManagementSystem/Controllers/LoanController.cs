using LibraryManagementSystem.Models.Dtos;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost(Name = "AddLoan")]
        public IActionResult AddLoan([FromBody] LoanDetailDto loan)
        {
            var result = _loanService.Add(loan);
            return Ok(result);
        }

        [HttpGet(Name ="GetAllLoans")]
        public IActionResult GetAllLoans()
        {
            var loans = _loanService.GetAll();

            return Ok(loans);
        }
        [HttpPut(Name ="UpdateLoanState")]
        public IActionResult UpdateLoanState([FromBody] LoanStateDto loanStateDto)
        {
            var result = _loanService.SetLoanState(loanStateDto);
            return Ok(result);
        }
    }
}
