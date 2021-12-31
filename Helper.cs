using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSharp
{
    public static class Helper
    {
        public static void Swap(List<int> res, int i, int j)
        {
            int temp = res[i];
            res[i] = res[j];
            res[j] = temp;
        }
    }
}
