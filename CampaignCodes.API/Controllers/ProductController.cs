
using CampaignCodes.Core.Repository.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampaignCodes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		
		[HttpGet("GetList")]
		public List<Code> GetList()
		{
			Code code = new Code();
			return code.GetCodeList();
		}

		// GET: api/<ProductController>
		[HttpPost("CodeGenerates")]
		public IEnumerable<Code> CodeGenerates(CodeParameter parameter)
		{
			Code code = new Code();
			return code.CodeGenerates(parameter.CodeLength, parameter.CodeCount); ;
		}
		
		// POST api/<ProductController>/5
		[HttpPost("Check")]
		public Code Check(Code userCode)
		{
			Code code2 = new Code();
			return code2.CodeCheck(userCode.UniqueCode);
		}
	}
}
public class CodeParameter
{
	public int CodeLength { get; set; } = 8;
	public int CodeCount { get; set; } = 1000;
}