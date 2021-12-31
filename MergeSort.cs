using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSharp
{
    /*
归并排序体现了 “分而治之” 的算法思想，具体为：

「分」： 不断将数组从 中点位置 划分开，将原数组的排序问题转化为子数组的排序问题；
「治」： 划分到子数组长度为 1 时，开始向上合并，不断将 左右两个较短排序数组 合并为 一个较长排序数组，直至合并至原数组时完成排序；

算法流程：
    递归划分：

        计算数组中点 mm ，递归划分左子数组 merge_sort(l, m) 和右子数组 merge_sort(m + 1, r) ；

        当 l \geq rl≥r 时，代表子数组长度为 1 或 0 ，此时 终止划分 ，开始合并；

    合并子数组：

        暂存数组 numsnums 闭区间 [l, r][l,r] 内的元素至辅助数组 tmptmp ；

        循环合并： 设置双指针 ii , jj 分别指向 tmptmp 的左 / 右子数组的首元素；

        注意： numsnums 子数组的左边界、中点、右边界分别为 ll , mm , rr ，而辅助数组 tmptmp 中的对应索引为 00 , m - lm−l , r - lr−l ；

        当 i == m - l + 1i==m−l+1 时： 代表左子数组已合并完，因此添加右子数组元素 tmp[j]tmp[j] ，并执行 j = j + 1j=j+1 ；
        否则，当 j == r - l + 1j==r−l+1 时： 代表右子数组已合并完，因此添加左子数组元素 tmp[i]tmp[i] ，并执行 i = i + 1i=i+1 ；
        否则，当 tmp[i] \leq tmp[j]tmp[i]≤tmp[j] 时： 添加左子数组元素 tmp[i]tmp[i] ，并执行 i = i + 1i=i+1 ；
        否则（即当 tmp[i] > tmp[j]tmp[i]>tmp[j] 时）： 添加右子数组元素 tmp[j]tmp[j] ，并执行 j = j + 1j=j+1 ；

     **/
    public static class MergeSort
    {
        public static void Sort(List<int> res, int left, int right)
        {
            if (left >= right) return;
            int middle = (left + right)/2;
            Sort(res, left, middle);
            Sort(res, middle + 1, right);
            List<int> temp = new List<int>();//temp_left=0;temp_middle=middle-left+1;temp_right = right-left+1
            int i = 0;
            int j = middle - left + 1;
            for (int k = left; k <= right; k++)
            {
                temp.Add(res[k]);
            }
            for (int l = left; l <= right; l++)
            {
                if (i >= middle - left + 1)
                {
                    res[l] = temp[j++];
                }
                else if (j >=right-left+1 || temp[i] < temp[j])
                {
                    res[l] = temp[i++];
                }
                else
                {
                    res[l] = temp[j++];
                }
            }
        }
    }
}
