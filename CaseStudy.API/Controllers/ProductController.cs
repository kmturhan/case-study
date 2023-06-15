
using CaseStudy.Core.Repository.Concrete;
using CaseStudy.Core.Repository.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseStudy.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		
		[HttpGet("GetList")]
		public List<Code> GetList()
		{
			return CodeProvider.Instance.GetCodeList();
		}

		[HttpPost("CodeGenerates")]
		public IEnumerable<Code> CodeGenerates(int codeLength = 8, int codeCount = 1000)
		{
			return CodeProvider.Instance.CodeGenerates(codeLength, codeCount);
		}
		[HttpPost("CodeGeneratesWithCharSet")]
		public IEnumerable<Code> CodeGenerates(int codeLength = 8, int codeCount = 1000, string charSetParam = "ACDEFGHKLMNPRTXYZ234579")
		{
			return CodeProvider.Instance.CodeGenerates(codeLength, codeCount, charSetParam);
		}

		[HttpPut("UseCode")]
		public Code UseCode(string userCode)
		{
			return CodeProvider.Instance.CodeCheck(userCode);
		}

		[HttpPut("UseCodes")]
		public List<Code> UseCode(List<string> userCode)
		{
			return CodeProvider.Instance.CodeCheck(userCode);
		}
	}
}