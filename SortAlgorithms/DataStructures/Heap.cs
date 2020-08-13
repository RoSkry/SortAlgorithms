using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithms.DataStructures
{
    public class Heap<T> where T : IComparable
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;


        public Heap()
        {

        }
        public Heap(IEnumerable<T> items)
        {
            _items.AddRange(items);
            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }

        public void Add(T item)
        {
            _items.Add(item);
            var currentIndex = Count - 1;
            var parentIndex = GetParentIndex(currentIndex);

            while (currentIndex > 0 && _items[parentIndex].CompareTo(_items[currentIndex]) == 1)
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        public T GetMax()
        {
            var result = _items[0];
            _items[0] = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }

        private void Sort(int currentIndex)
        {
            int leftIndex, rightIndex;
            int maxIndex = currentIndex;
            while (currentIndex < Count)
            {
                leftIndex = 2 * currentIndex + 1;
                rightIndex = 2 * currentIndex + 2;

                if (leftIndex < Count && _items[leftIndex].CompareTo(_items[maxIndex]) == -1)
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < Count && _items[rightIndex].CompareTo(_items[maxIndex]) == -1)
                {
                    maxIndex = rightIndex;
                }

                if (maxIndex == currentIndex)
                {
                    break;
                }

                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;

            }
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            var temp = _items[currentIndex];
            _items[currentIndex] = _items[parentIndex];
            _items[parentIndex] = temp;
        }

        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        public List<T> Order()
        {
            var result = new List<T>();
            while (Count > 0)
            {
                result.Add(GetMax());
            }
            return result;
        }
    }
}
