// Sorting Data
// Name : Quick Sort
// Best : n log n
// Average : n log n
// Worst : n²
// Memory : (log n) on average, worst case is (n); Sedgewick variation is (log n) worst case
// Stable : typeical in-place sort is not stable; stable versions exist

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Sort
{
    public class SortModeQuick : SortModeBase
    {
        public override List<T> CompareRoutine<T>(List<T> sortList, SortCenter.delCompareFunction<T> func)
        {
            Quick<T>(ref sortList, 0, sortList.Count-1, func);
            return sortList;
        }

        private void Quick<T>(ref List<T> sortList, int left, int right, SortCenter.delCompareFunction<T> func)
        {
            if (left >= right) return;

            int i = left+1;
            int j = right;

            int pivot = left;

            while (true)
            {
                for (; (i <= right) && !func(sortList[i], sortList[pivot]); i++) ;
                for (; (j >= left) && func(sortList[j], sortList[pivot]); j--) ;
            
                if (i < j)
                {
                    SwapList<T>(ref sortList, i, j);
                }
                else
                {
                    SwapList<T>(ref sortList, j, pivot);
                    break;
                }
            }

            Quick<T>(ref sortList, left, j-1, func);
            Quick<T>(ref sortList, j+1, right, func);
        }
    }
}