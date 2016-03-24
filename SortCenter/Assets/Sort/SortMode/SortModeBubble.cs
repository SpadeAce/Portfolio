// Sorting Data
// Name : Bubble Sort
// Best : n
// Average : n²
// Worst : n²
// Memory : 1
// Stable : Yes

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Sort
{
    public class SortModeBubble : SortModeBase
    {
        public override List<T> CompareRoutine<T>(List<T> sortList, SortCenter.delCompareFunction<T> func)
        {
            for (int i = sortList.Count; i > 1; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (func(sortList[j - 1], sortList[j]))
                    {
                        SwapList<T>(ref sortList, j - 1, j);
                    }
                }
            }
            return sortList;
        }
    }
}