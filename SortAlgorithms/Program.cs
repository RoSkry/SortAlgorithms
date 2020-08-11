using System;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var sorting = new Sortings(new int[] { 7, 4, 9, 3, 6, 5 });

            //  var result = sorting.BubbleSorting();
            // var result = sorting.ShakerSorting();
            var result = sorting.InsertSorting();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
