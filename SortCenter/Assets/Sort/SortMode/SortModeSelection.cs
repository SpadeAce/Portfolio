// Sorting Data
// Name : Selection Sort
// Best : n²
// Average : n²
// Worst : n²
// Memory : 1
// Stable : No

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Sort
{
    public class SortModeSelection : SortModeBase
    {
        public override List<T> CompareRoutine<T>(List<T> sortList, SortCenter.delCompareFunction<T> func)
        {
            int min = 0;
            for (int i = 0; i < sortList.Count-1; i++)
            {
                min = i;
                for (int j = i+1; j < sortList.Count; j++)
                {
                    if (func(sortList[min], sortList[j]))
                    {
                        min = j;
                    }
                }

                if (min != i)
                    SwapList<T>(ref sortList, i, min);
            }
            return sortList;
        }
    }
}