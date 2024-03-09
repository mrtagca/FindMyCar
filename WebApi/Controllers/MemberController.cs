using BaseTypes;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using RequestTypes;

namespace WebApi.Controllers
{
    public class MemberController : BaseController
    {
        MemberRepository _memberRepository;
        public MemberController(MemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        [HttpPost]
        public ResponseBase AddMember(AddMemberRequest request)
        {
            ResponseBase response = new ResponseBase(); 

            Member member = new Member()
            {
                Phone = request.Phone,
                Gender = request.Gender,
            };
            DbResultBase dbResult = _memberRepository.AddMember(member);
            if (dbResult.Success)
            {
                response.Success = dbResult.Success;
                response.RecordId = dbResult.RecordId.ToString();
            }
            else
            {
                response.Success = false;
                response.Error = new Error(dbResult.Error.Message);
            }
            
            return response;
        }
    }
}
