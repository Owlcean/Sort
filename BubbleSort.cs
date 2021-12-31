using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSharp
{
    /*
冒泡排序是最基础的排序算法，由于其直观性，经常作为首个介绍的排序算法。其原理为：

内循环： 使用相邻双指针 j , j + 1 从左至右遍历，依次比较相邻元素大小，若左元素大于右元素则将它们交换；遍历完成时，最大元素会被交换至数组最右边 。

外循环： 不断重复「内循环」，每轮将当前最大元素交换至 剩余未排序数组最右边 ，直至所有元素都被交换至正确位置时结束。

复杂度分析：
时间复杂度 O(N^2)其中 N 为输入数组的元素数量「外循环」共N−1 轮，使用O(N) 时间；每轮「内循环」分别遍历 N−1 , N−2 , .. , 2 , 1 次，平均  N/2次，使用O(N) 时间；因此，总体时间复杂度为 O(N^2)
空间复杂度 O(1) ： 只需原地交换元素，使用常数大小的额外空间。
算法特性：
时间复杂度为 O(N^2)，因为其是通过不断 交换元素 实现排序（交换 2 个元素需要 3 次赋值操作），因此速度较慢；
原地： 指针变量仅使用常数大小额外空间，空间复杂度为 O(1) ；
稳定： 元素值相同时不交换，因此不会改变相同元素的相对位置；
自适应： 通过增加一个标志位 flag ，若某轮内循环未执行任何交换操作时，说明已经完成排序，因此直接返回。此优化使冒泡排序的最优时间复杂度达到 O(N)O(N)（当输入数组已排序时）；

     * */
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

        /*
    通过增加一个标志位 flag ，若在某轮「内循环」中未执行任何交换操作，则说明数组已经完成排序，直接返回结果即可。
    优化后的冒泡排序的最差和平均时间复杂度仍为 O(N^2)在输入数组 已排序 时，达到 最佳时间复杂度 Ω(N) 。
         * */
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
