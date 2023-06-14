
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

		// GET: api/<ProductController>
		[HttpPost("CodeGenerates")]
		public IEnumerable<Code> CodeGenerates(CodeParameter parameter)
		{
			CodeProvider code = new CodeProvider();
			return CodeProvider.Instance.CodeGenerates(parameter.CodeLength, parameter.CodeCount); ;
		}
		
		// POST api/<ProductController>/5
		[HttpPost("Check")]
		public Code Check(Code userCode)
		{
			CodeProvider code = new CodeProvider();
			return CodeProvider.Instance.CodeCheck(userCode.UniqueCode);
		}
	}
}
public class CodeParameter
{
	public int CodeLength { get; set; } = 8;
	public int CodeCount { get; set; } = 1000;
}