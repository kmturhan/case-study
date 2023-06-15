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
			/*
			 * En son datayı döneceğimiz listeyi tanımlıyoruz.
			 */
			List<OcrResult> result = new List<OcrResult>();
			/* 
			 * CaseStudy.API projesinde DummyFile klasörünün altında response.json bulunuyor.
			 * Dosya işlemleri satır 33'e kadar bu işlem gerçekleştiriliyor.
			 */
			string fullPath = Path.Combine(Environment.CurrentDirectory, @"DummyFile\", "response.json");
			
			using (StreamReader sr = new StreamReader(fullPath))
			{
				string json = sr.ReadToEnd();
				/*
				 * Burada json formatıyla aynı olan bir class kullanılıyor.
				 * Deserialize işlemiyle bütün data listeye aktarılıyor.
				 */
				List<Ocr> items = JsonConvert.DeserializeObject<List<Ocr>>(json);

				/*
				 * Okunan datayı daha rahat işleyebileceğimiz farklı bir class'a aktarıyoruz.
				 */ 
				List<BoundingPoly> newParseJson = new List<BoundingPoly>();
				foreach (var item in items)
				{
					/*
					 * Bu blok içinde 4 farklı koordinatı verilen kelimenin orta noktasını bulmayı amaçlanıyor.
					 * Bu yüzden kelimenin x ve y koordinatlarının ortalamalarınız alınıyor.
					 * Ayrıca bir alt object içine kelimeyi bulmak zor olmasın diye 'description2' alanına taşınıyor.
					 */
					item.BoundingPoly.Description2 = item.Description;
					item.BoundingPoly.AvgX = item.BoundingPoly.Vertices.Average(x => x.X);
					item.BoundingPoly.AvgY = item.BoundingPoly.Vertices.Average(x => x.Y);

					/*
					 * İşlemler bitince yeni oluşturulan object yeni listeye aktarılıyor.
					 */
					newParseJson.Add(item.BoundingPoly);
				}

				/*
				 * Aynı sırada olan kelimeleri gruplayabilmek için string array tanımlanıyor.
				 */
				List<string> rows = new List<string>();
				foreach (var item in newParseJson.ToList())
				{
					/*
					 * Aynı sırada olup olmadığını anlamak için Y değerini baz almamız gerekiyor.
					 * 'currentAvgY' değişkenine her kelimenin ortalaması alınan y değeri aktarılıyor.
					 */
					double currentAvgY = item.AvgY;
					/*
					 * Koordinatlar stabil olarak gelmediği için hata payını da göz önünde bulundurmamız gerekiyor.
					 * 'Ocr.standartDeviation' statik bir değişken bulunuyor. Bu görselden görsele değişebilir.
					 * 'Ocr.standartDeviation' bu değişkenin yaptığı iş diğer kelimelerin, seçilen kelimeyle + veya - 10 
					 * y ekseninde hizada olup olmamasını kontrol ediyor. Eğer şartlar sağlanırsa liste biçiminde 'currentRowWords' 'e aktarılıyor.
					 */
					var currentRowWords = newParseJson.Where(x => (currentAvgY - Ocr.standardDeviation) <= x.AvgY && x.AvgY <= (currentAvgY + Ocr.standardDeviation)).ToList();	
					/*
					 * Aynı satırda bulunan kelimeler join metoduyla listeye ekleniyor.
					 */
					rows.Add(string.Join(" ", currentRowWords.Select(x => x.Description2)));
					foreach (var currentWord in currentRowWords)
                    {
						/*
						 * Aynı sırada olan tüm kelimeler listeden siliniyor.
						 */
						newParseJson.Remove(currentWord);
                    }
                }
				/*
				 * En son listedeki boş elemanlar listeden siliniyor.
				 */
				rows = rows.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
				/*
				 * response.json içinde ilk object tüm data olduğu için skip metoduyla bu object atlanıyor.
				 */
				int lineNumber = 0;
				foreach (var item in rows.Skip(1))
				{
					/*
					 * Oluşturduğumuz kelimeleri dönüş yapacağımız listeye aktarıyoruz.
					 */
					result.Add(new OcrResult { Line = ++lineNumber, Text = item});
				}
			}
			return result;
		}
	}
}
