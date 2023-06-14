using CaseStudy.Core.Repository.Concrete;

namespace CaseStudy.Core.Repository.Abstract
{
	public interface ICode
	{
		List<Code> GetCodeList();
		List<Code> CodeGenerates(int codeLength, int codeCount);
		List<Code> CodeCheck(List<string> codes);
		Code CodeCheck(string code);
	}
}
