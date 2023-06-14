using CaseStudy.Core.Repository.Abstract;

namespace CaseStudy.Core.Repository.Concrete
{
	public class Code : ICode
	{
		public int Id { get; set; }
		public string UniqueCode { get; set; }
		public bool IsValid { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }


		string str = "ACDEFGHKLMNPRTXYZ234579";
		private List<char> charSet = new List<char>();
		private static List<Code> codeList = new List<Code>();

		public Code()
		{
			charSet.AddRange(str);
		}
		public List<Code> GetCodeList()
		{
			return codeList;
		}
		public List<Code> CodeGenerates(int codeLength, int codeCount)
		{
			Random rd = new Random();
			for (int i = 1; i <= codeCount; i++)
			{
			section1:
				string code = "";
				while (code.Length != codeLength)
				{
					int arrayIndex = rd.Next(0, charSet.Count);
					char character = charSet[arrayIndex];
					code += character;
				}
				if (codeList.Any(x => x.UniqueCode == code))
				{
					goto section1;
				}
				codeList.Add(new Code { Id = 1, UniqueCode = code, IsValid = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
			}
			return codeList;
		}
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
