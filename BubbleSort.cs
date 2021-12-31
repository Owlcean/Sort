using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSharp
{
    public static class BubbleSort
    {
        public static List<int> NormalSort(List<int> res)
        {
            int length = res.Count;
            int count = 0;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (res[j] < res[j + 1])
                    {
                        Helper.Swap(res, j, j + 1);
                    }
                    count++;
                }
            }
            return res;
        }

        public static List<int> FlagSort(List<int> res)
        {
            int length = res.Count;
            bool flag;
            int count = 0;
            for (int i = 0; i < length - 1; i++)
            {
                flag = false;
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (res[j] < res[j + 1])
                    {
                        Helper.Swap(res, j, j + 1);
                        flag = true;
                    }
                    count++;
                }
                 if (!flag) break;
            }
            //Console.WriteLine(string.Format("sort list:{0}", res));
            return res;
        }
    }
}
