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


        private void Swap(int k, int v)
        {
            var temp = arr[k];
            arr[k] = arr[v];
            arr[v] = temp;
        }
    }
}
