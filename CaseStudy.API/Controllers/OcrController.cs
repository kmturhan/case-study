using CaseStudy.Core.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CaseStudy.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OcrController : ControllerBase
	{
		[HttpGet("JsonParse")]
		public List<OcrResult> JsonParse()
		{
			
			string fullPath = Path.Combine(Environment.CurrentDirectory, @"DummyFile\", "response.json");
			List<OcrResult> result = new List<OcrResult>();
			using (StreamReader sr = new StreamReader(fullPath))
			{
				string json = sr.ReadToEnd();
				List<Ocr> items = JsonConvert.DeserializeObject<List<Ocr>>(json);
				List<BoundingPoly> newParseJson = new List<BoundingPoly>();
				foreach (var item in items)
				{
					item.BoundingPoly.Description2 = item.Description;
					item.BoundingPoly.AvgX = item.BoundingPoly.Vertices.Average(x => x.X);
					item.BoundingPoly.AvgY = item.BoundingPoly.Vertices.Average(x => x.Y);

					newParseJson.Add(item.BoundingPoly);
				}
				List<string> rows = new List<string>();
				foreach (var item in newParseJson.ToList())
				{
					double avgy = item.AvgY;
					var currentRowWords = newParseJson.Where(x => (avgy - Ocr.standardDeviation) <= x.AvgY && x.AvgY <= (avgy + Ocr.standardDeviation)).ToList();	
					rows.Add(string.Join(" ", currentRowWords.Select(x => x.Description2)));
					foreach (var item1 in currentRowWords)
                    {
						newParseJson.Remove(item1);
                    }
                }
				rows = rows.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();


				int lineNumber = 0;
				foreach (var item in rows.Skip(1))
				{
					result.Add(new OcrResult { Line = ++lineNumber, Text = item});
				}
			}
			return result;
		}
	}
}
