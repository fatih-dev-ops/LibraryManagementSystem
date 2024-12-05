using LibraryManagementSystem.Models.Dtos;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }


        [HttpGet(Name = "GetMemberbyId")]
        public IActionResult GetMemberById(int id)
        {
            var member = _memberService.GetById(id);

            if (member is not null)
            {
                return Ok(member);
            }
            else 
                return NotFound(new { Message = "Item not found.", ItemId = id });
        }

        [HttpPut(Name ="SetMemberState")]
        public IActionResult SetMemberState([FromBody] MemberDetailDto memberDetailDto)
        {

            var result = _memberService.SetMemberState(memberDetailDto);
            if (result is bool)
            {
                if (!result)
                {
                    return NotFound(new { Message = "Lütfen farklı bir state durumu belirleyin.", StateValue = memberDetailDto.State });
                }
            }
            return Ok(result);
        }
        [HttpGet(Name = "GetAllMembers")]
        public IActionResult GetAllMembers()
        {
            var members = _memberService.GetAll();
            return Ok(members);
        }

        [HttpGet(Name = "GetLoanHistory")]
        public IActionResult GetLoanHistory(int id)
        {
            //Eğer id ye ait loan yoksa servisten nasıl cevap dönsün nasıl oluyor?
            var memberLoans = _memberService.GetLoanHistory(id);
            if (memberLoans is not null)
            {
                return Ok(memberLoans);
            }
            else
                return NotFound(new { Message = "There is no any loans for member.", MemberId = id });
        }

        [HttpPut(Name = "UpdateUserInfos")]
        public IActionResult UpdateUserInfos([FromBody] MemberDetailDto memberDetailDto)
        {
            var result = _memberService.Update(memberDetailDto);
            return Ok(new { Message = result, Member = memberDetailDto });
        }

        [HttpPost(Name = "CreateMember")]
        public IActionResult AddMember([FromBody] MemberDetailDto memberDetailDto)
        {
            var result = _memberService.Add(memberDetailDto);
            return Ok(new { Message = result, Member = memberDetailDto });
        }

    }
}
