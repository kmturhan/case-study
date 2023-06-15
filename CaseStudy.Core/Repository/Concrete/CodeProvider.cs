using CaseStudy.Core.Repository.Abstract;
using CaseStudy.Core.Repository.Models;

namespace CaseStudy.Core.Repository.Concrete
{
	public class CodeProvider : ICode
	{
		
		private static CodeProvider instance = null;
		//Farklı yerlerde de aynı kod listesini performans açısından singleton pattern kullanılıyor.
		public static CodeProvider Instance => instance ?? (instance = new CodeProvider());
		//'CodeGenerates' endpoint'ine charset gönderilmezse eğer buradaki charset geçerli oluyor. İçerden yönetilebilir durumda.  
		private static string stringCharSet = "ACDEFGHKLMNPRTXYZ234579";
		//Karakter seti array olarak tutuluyor.
		private static List<char> charSet = stringCharSet.ToList();
		//Veritabanı kullanmadığımız için statik nesne içerisinde oluşturulan kodları tutuluyor. 
		private static List<Code> codeList = new List<Code>();
		
		/*
		 * Güncel kod listesini dönüyor.
		 */
		public List<Code> GetCodeList()
		{
			return codeList;
		}

		/*
		 * 'codeLength' kodun kaç karakterden oluşacağı;
		 * 'codeCount' kaç adet kod üretileceği anlamına geliyor.
 		 */
		public List<Code> CodeGenerates(int codeLength, int codeCount)
		{
			Random rd = new Random();
			for (int i = 1; i <= codeCount; i++)
			{
				
			section1:
				string code = "";
				while (code.Length != codeLength)
				{
					/*
					 * Random olarak charSet uzunluğunda bir sayı üretilip yine charset içinden rastgele biçimde 
					 * bir karakter alınıyor ve code değişkenine parametre gönderilen codeLength'e kadar eklenmeye devam ediyor.
					 */
					int arrayIndex = rd.Next(0, charSet.Count);
					char character = charSet[arrayIndex];
					code += character;
				}
				if (codeList.Any(x => x.UniqueCode == code))
				{
					/*
					 * 'section1' etiketi daha önce üretilmiş bir kod varsa tekrar başa dönmeyi sağlıyor.
					 */
					goto section1;
				}
				/*
				 * Herhangi bir sorun yoksa listeye('codelist') ekleniyor.
				 */
				codeList.Add(new Code { UniqueCode = code, IsValid = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
			}
			return codeList;
		}
		/*
		 * Üst taraftaki metodun göreviyle aynı sadece charset kullanan kişi tarafından parametre olarak gönderilebiliyor.
		 */
		public List<Code> CodeGenerates(int codeLength, int codeCount, string charSetParam)
		{
			/*
			 * charSet'i burada manipüle ediyoruz.
			 */
			charSet = charSetParam.ToList();
			Random rd = new Random();
			for (int i = 1; i <= codeCount; i++)
			{
			RecreateCode:
				string code = "";
				while (code.Length != codeLength)
				{
					int arrayIndex = rd.Next(0, charSet.Count);
					char character = charSet[arrayIndex];
					code += character;
				}
				if (codeList.Any(x => x.UniqueCode == code))
				{
					goto RecreateCode;
				}
				codeList.Add(new Code { UniqueCode = code, IsValid = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
			}
			return codeList;
		}
		/*
		 * Liste biçiminde birden fazla kod kullanıcı tarafından eklenebiliyor.
		 * Kullanılan kodun IsValid alanı 'true' olarak güncelleniyor.
 		 */
		public List<Code> CodeCheck(List<string> codes)
		{
			List<Code> checkedList = new List<Code>();
			foreach (var code in codes)
			{
				var item = codeList.FirstOrDefault(x => x.UniqueCode == code);
				if (item != null)
				{
					item.IsValid = true;
					item.UpdatedDate = DateTime.Now;
					checkedList.Add(item);
				}
			}
			return checkedList;
		}

		/*
		 * Tekil biçimde kullanıcı tarafından kod eklenebiliyor.
		 * Kullanılan kodun IsValid alanı 'true' olarak güncelleniyor.
		 */
		public Code CodeCheck(string code)
		{
			var item = codeList.SingleOrDefault(x => x.UniqueCode == code);
			if (item != null)
			{
				item.IsValid = true;
				item.UpdatedDate = DateTime.Now;

			}
			return item;
		}
	}
}
