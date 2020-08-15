using SortAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortAlgorithms
{
    public class Sortings
    {
        private int[] arr;
        public Sortings(int[] collection)
        {
            arr = collection;
        }

        public IEnumerable<int> BubbleSorting()
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.Count(); i++)
                {
                    for (int j = 0; j < arr.Count() - i - 1; j++)
                    {
                        var a = arr[j];
                        var b = arr[j + 1];
                        if (a > b)
                        {
                            Swap(j, j + 1);
                        }
                    }
                }
                return arr;
            }
            else
            {
                return default(int[]);
            }
        }

        public IEnumerable<int> ShakerSorting()
        {
            if (arr != null)
            {
                int left = 0;
                int right = arr.Length - 1;

                while (left < right)
                {
                    for (int i = left; i < right; i++)
                    {
                        var a = arr[i];
                        var b = arr[i + 1];
                        if (a > b)
                        {
                            Swap(i, i + 1);
                        }
                    }
                    right--;

                    for (int i = right; i > left; i--)
                    {
                        var a = arr[i];
                        var b = arr[i - 1];
                        if (b > a)
                        {
                            Swap(i - 1, i);
                        }
                    }
                    left++;
                }
                return arr;
            }
            else
            {
                return default(int[]);
            }
        }

        public IEnumerable<int> InsertSorting()
        {
            if (arr != null)
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    var temp = arr[i];
                    var j = i;
                    while (j > 0 && arr[j - 1] > temp)
                    {
                        arr[j] = arr[j - 1];
                        --j;
                    }
                    arr[j] = temp;
                }
                return arr;
            }
            else
            {
                return default(int[]);
            }
        }

        public IEnumerable<int> SelectionSorting()
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    var min = i;
                    for (int j = min + 1; j < arr.Length; j++)
                    {
                        if (arr[j] < arr[min])
                        {
                            min = j;
                        }
                    }
                    Swap(i, min);
                }
                return arr;
            }
            else
            {
                return default(int[]);
            }
        }

        public IEnumerable<int> ShellSorting()
        {
            if (arr != null)
            {
                var step = arr.Length / 2;
                while (step > 0)
                {
                    for (int i = step; i < arr.Length; i++)
                    {
                        var j = i;
                        while (j >= step && arr[j - step] > arr[j])
                        {
                            Swap(j, j - step);
                            j = j - step;
                        }
                    }
                    step /= 2;
                }
                return arr;
            }
            else
            {
                return default(int[]);
            }
        }

        public IEnumerable<int> TreeSorting()
        {
            var tree = new Tree<int>(arr);
            var sortedArr = tree.InOrder();
            return sortedArr;
        }

        public IEnumerable<int> HeapSorting()
        {
            var heap = new Heap<int>(arr);
            var sortedArr = heap.Order();
            return sortedArr;
        }

        public IEnumerable<int> MergeSorting()
        {
            return Sort(arr.ToList());
        }

        private List<int> Sort(List<int> collection)
        {
            if (collection.Count() == 1)
            {
                return collection;
            }
            var mid = collection.Count() / 2;

            var left = collection.Take(mid).ToList();
            var right = collection.Skip(mid).ToList(); ;

            return Merge(Sort(left), Sort(right));
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            var length = left.Count() + right.Count();
            var leftPointer = 0;
            var rightPointer = 0;

            var result = new List<int>();

            for (int i = 0; i < length; i++)
            {
                if (leftPointer < left.Count() && rightPointer < right.Count())
                {
                    if (right[rightPointer] > left[leftPointer])
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                    else
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                }
                else
                {
                    if (rightPointer < right.Count())
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                    else
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                }
            }

            return result;
        }

        public IEnumerable<int> RadixSort()
        {
            var groups = new List<List<int>>();
            for (int i = 0; i < 10; i++)
            {
                groups.Add(new List<int>());
            }

            var length = GetMaxLength();

            // Распределение элементов по корзинам. 
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    int temp = (arr[j] % (int)Math.Pow(10, i + 1)) / (int)Math.Pow(10, i);
                    groups[temp].Add(arr[j]);
                }

                // Сборка элементов.
                var k = 0;
                for (int ii = 0; ii < 10; ii++)
                {
                    for (int j = 0; j < groups[ii].Count; j++)
                    {
                        arr[k++] = (int)groups[ii][j];
                    }
                }

                for (int i1 = 0; i1 < 10; i1++)
                {
                    groups[i1].Clear();
                }
            }
            return arr;
        }

        private int GetMaxLength()
        {
            int length = 0;
            foreach (var item in arr)
            {
                var itemLenght = Convert.ToInt32(Math.Log10(item));
                if (itemLenght > length)
                {
                    length = itemLenght;
                }
            }

            return length;
        }

        private void Swap(int k, int v)
        {
            var temp = arr[k];
            arr[k] = arr[v];
            arr[v] = temp;
        }
    }
}
