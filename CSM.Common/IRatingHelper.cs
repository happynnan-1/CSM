using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSM.Common
{
    public interface IRatingHelper<T> where T : class
    {
        List<T> GetCommonCodeByType(string category);

        T GetCommonCodeByID(int codeId);

        T GetCommonCodeByCode(string code, string category);
    }
}
