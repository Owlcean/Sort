using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSharp
{
    /*
算法特性
时间复杂度：

最佳 Ω(NlogN) ： 最佳情况下， 每轮哨兵划分操作将数组划分为等长度的两个子数组；哨兵划分操作为线性时间复杂度 O(N) ；递归轮数共 O(logN) 。

平均 Θ(NlogN) ： 对于随机输入数组，哨兵划分操作的递归轮数也为 O(logN) 。

最差 O(N^2)： 对于某些特殊输入数组，每轮哨兵划分操作都将长度为 NN 的数组划分为长度为 1 和 N−1 的两个子数组，此时递归轮数达到 NN 。

通过 「随机选择基准数」优化，可尽可能避免出现最差情况，详情请见下文。

空间复杂度 O(N) ： 快速排序的递归深度最好与平均皆为 logN ；输入数组完全倒序下，达到最差递归深度 NN 。

通过「Tail Call」优化，可将最差空间复杂度降低至 O(logN) ，详情请见下文。

虽然平均时间复杂度与「归并排序」和「堆排序」一致，但在实际使用中快速排序 效率更高 ，这是因为：

最差情况稀疏性： 虽然快速排序的最差时间复杂度为 O(N^2) ，差于归并排序和堆排序，但统计意义上看，这种情况出现的机率很低。大部分情况下，快速排序以O(NlogN) 复杂度运行。
缓存使用效率高： 哨兵划分操作时，将整个子数组加载入缓存中，访问元素效率很高；堆排序需要跳跃式访问元素，因此不具有此特性。
常数系数低： 在提及的三种算法中，快速排序的 比较、赋值、交换 三种操作的综合耗时最低（类似于插入排序快于冒泡排序的原理）。
原地： 不用借助辅助数组的额外空间，递归仅使用 O(logN) 大小的栈帧空间。

非稳定： 哨兵划分操作可能改变相等元素的相对顺序。

自适应： 对于极少输入数据，每轮哨兵划分操作都将长度为 N 的数组划分为长度 1 和 N−1 两个子数组，此时时间复杂度劣化至 O(N^2)
     * */
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

        /*
Tail Call ：
    由于普通快速排序每轮选取「子数组最左元素」作为「基准数」，因此在输入数组 完全倒序 时， partition() 的递归深度会达到 N ，即 最差空间复杂度 为 O(N) 。
    每轮递归时，仅对 较短的子数组 执行哨兵划分 partition() ，就可将最差的递归深度控制在 O(log N) （每轮递归的子数组长度都 ≤ 当前数组长度 /2 ），即实现最差空间复杂度O(logN) 。
         * */
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

        /*
随机基准数：
    同样地，由于快速排序每轮选取「子数组最左元素」作为「基准数」，因此在输入数组 完全有序 或 完全倒序 时， partition() 每轮只划分一个元素，达到最差时间复杂度 O(N^2)
    因此，可使用 随机函数 ，每轮在子数组中随机选择一个元素作为基准数，这样就可以极大概率避免以上劣化情况。
    值得注意的是，由于仍然可能出现最差情况，因此快速排序的最差时间复杂度仍为 O(N^2)
         * */
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
