using CaseStudy.Core.Repository.Concrete;
using CaseStudy.Core.Repository.Models;

namespace CaseStudy.Core.Repository.Abstract
{
	public interface ICode
	{
		List<Code> GetCodeList();
		List<Code> CodeGenerates(int codeLength, int codeCount);
		List<Code> CodeGenerates(int codeLength, int codeCount, string charSetParam);
		List<Code> CodeCheck(List<string> codes);
		Code CodeCheck(string code);
	}
}
