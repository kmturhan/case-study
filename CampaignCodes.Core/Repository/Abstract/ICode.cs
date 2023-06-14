using CampaignCodes.Core.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignCodes.Core.Repository.Abstract
{
	public interface ICode
	{
		List<Code> GetCodeList();
		List<Code> CodeGenerates(int codeLength, int codeCount);
		List<Code> CodeCheck(List<string> codes);
		Code CodeCheck(string code);
	}
}
