using CampaignCodes.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampaignCodes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OcrController : ControllerBase
	{
		[HttpGet("OcrJsonParse")]
		public List<OcrModel> OcrJsonParse()
		{

			return new List<OcrModel>();
		}
	}
}
