using System;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var sorting = new Sortings(new int[] { 7, 4, 9, 3, 6, 5 });
            // var sorting = new Sortings(new int[] { 77, 138, 284, 141, 356, 99 });
            //  var result = sorting.BubbleSorting();
            // var result = sorting.ShakerSorting();
            // var result = sorting.InsertSorting();
            // var result = sorting.SelectionSorting();
            //  var result = sorting.ShellSorting();
            //  var result = sorting.TreeSorting();
            // var result = sorting.HeapSorting();
            //  var result = sorting.MergeSorting();
            // var result = sorting.RadixSort();
            // var result = sorting.GnomeSort();
            var result = sorting.QuickSort();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
