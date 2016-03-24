// Sorting Data
// Name : Insertion Sort
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
    public class SortModeInsertion : SortModeBase
    {
        public override List<T> CompareRoutine<T>(List<T> sortList, SortCenter.delCompareFunction<T> func)
        {
            for (int i = 1; i < sortList.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (func(sortList[j - 1], sortList[j]))
                    {
                        SwapList<T>(ref sortList, j - 1, j);
                    }
                    else
                        break;
                }
            }
            return sortList;
        }
    }
}