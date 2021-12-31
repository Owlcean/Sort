using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSharp
{
    public static class MergeSort
    {
        public static void NormalSort(List<int> res, int left, int right)
        {
            if (left >= right) return;
            int middle = (left + right) / 2;
            NormalSort(res, left, middle);
            NormalSort(res, middle + 1, right);
            List<int> temp = new List<int>();
            for (int k = left; k <= right; k++)
            {
                temp.Add(res[k]);
            }
            int i = 0;
            int j = middle -left + 1;
            for (int l = left; l <= right; l++)
            {
                if (i == middle - left + 1) { res[l] = temp[j++]; }
                else if (j == right - left + 1 || temp[i] < temp[j]) { res[l] = temp[i++]; }
                else{ res[l] = temp[j++]; }
            }
        }
    }
}
