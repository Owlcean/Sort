using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSharp
{
    public static class QuickSort
    {
        private static int recursionTime = 0;
        private static void AddRecursionTime()
        {
            recursionTime++;
        }
        public static int GetRecursionTime()
        {
            return recursionTime;
        }
        public static void ResetRecursionTime()
        {
            recursionTime = 0;
        }
        public static void NormalSort(List<int> res, int left, int right)
        {
            AddRecursionTime();
            if (left >= right) return;
            int i = Partition(res, left, right);

            NormalSort(res, left, i - 1);
            NormalSort(res, i + 1, right);
        }

        public static void TailCallSort(List<int> res, int left, int right)
        {
            if (left >= right) return;
            while (left < right)
            {
                int i = Partition(res, left, right);
                if (i - left < right - i)
                {
                    TailCallSort(res, left, i - 1);
                    left = i + 1;
                }
                else
                {
                    TailCallSort(res, i + 1, right);
                    right = i - 1;
                }
            }
        }

        public static void RandomBaseNumSort(List<int> res, int left, int right)
        {
            if (left >= right) return;
            int i = RandomBaseNumPartition(res, left, right);

            NormalSort(res, left, i - 1);
            NormalSort(res, i + 1, right);
        }


        private static int RandomBaseNumPartition(List<int> res, int left, int right)
        {
            Random ran = new Random();
            int randomIndex = ran.Next(left, right+1);
            Helper.Swap(res, left, randomIndex);
            int i = left;
            int j = right;
            while (i < j)
            {
                while (i < j && res[j] >= res[left])
                {
                    j--;
                }
                while (i < j && res[i] <= res[left])
                {
                    i++;
                }
                Helper.Swap(res, i, j);
            }
            Helper.Swap(res, left, i);
            return i;
        }

        private static int Partition(List<int> res, int left,int right)
        {
            int i = left;
            int j = right;
            while (i < j)
            {
                while (i < j && res[j] >= res[left])
                {
                    j--;
                }
                while (i < j && res[i] <= res[left])
                {
                    i++;
                }
                Helper.Swap(res, i, j);
            }
            Helper.Swap(res, left, i);
            return i;
        }
    }
}
