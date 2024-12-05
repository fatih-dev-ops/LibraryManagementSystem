//using LibraryManagementSystem.Models.Dtos;
//using LibraryManagementSystem.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace LibraryManagementSystem.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class MemberController : ControllerBase

//    {
//        private readonly IMemberService _memberService;

//        public MemberController(IMemberService memberService)
//        {
//            _memberService = memberService;
//        }

//        public IActionResult GetAllMembers()
//        {
//           var members = _memberService.GetAll();
//            return Ok(members);
//        }

//        public IActionResult GetMember(int id)
//        {
//            var member = _memberService.GetById(id);

//            if (member is not null)
//            {
//                return Ok(member);
//            }
//            else return NotFound(new { Message = "Item not found.", ItemId = id });
//        }

//        [HttpPut]
//        public IActionResult SetMemberState([FromBody] MemberDetailDto memberDetailDto)
//        {

//            var result = _memberService.SetMemberState(memberDetailDto);
//            if (!result)
//            {
//                return NotFound(new { Message = "Lütfen farklı bir state durumu belirleyin.", StateValue = memberDetailDto.State });
//            }
//            return Ok(result);
//        }

//        public IActionResult GetLoanHistory( int id)
//        {
//            //Eğer id ye ait loan yoksa servisten nasıl cevap dönsün nasıl oluyor?
//            var memberLoans = _memberService.GetLoanHistory(id);
//            return Ok(memberLoans);
//        }

//        [HttpPut]
//        public IActionResult UpdateUserInfos([FromBody] MemberDetailDto memberDetailDto)
//        {
//            var result = _memberService.Update(memberDetailDto);
//            return Ok(new { Message = result, Member = memberDetailDto });
//        }

//        [HttpPost]
//        public IActionResult AddMember([FromBody] MemberDetailDto memberDetailDto)
//        {
//            var result = _memberService.Add(memberDetailDto);
//            return Ok(new {Message = result, Member = memberDetailDto});
//        }
//    }
//}
