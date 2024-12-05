using LibraryManagementSystem.Models.Dtos;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("[controller]")]
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
            else return NotFound(new { Message = "Item not found.", ItemId = id });
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
    }
}
