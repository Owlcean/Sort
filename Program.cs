using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = GenNumbers(20);
            //BubbleSort.FlagSort(input);
            //QuickSort.ResetRecursionTime();
            //QuickSort.TailCallSort(input, 0, input.Count-1);、
            //Console.WriteLine("recur time:" + QuickSort.GetRecursionTime());
            MergeSort.Sort(input, 0, input.Count - 1);
            input.ForEach((element) => {
                Console.Write(element + " ");
            });

            Console.ReadKey();
        }

        static List<int> GenNumbers(int count)
        {
            List<int> res = new List<int>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                res.Add(random.Next(1, 99));
            }
            Console.WriteLine("GEN:");
            res.ForEach((element) =>
            {
                Console.Write(element + " ");
            });
            Console.WriteLine("");
            return res;
        }
    }
}
