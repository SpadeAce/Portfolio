// Sorting Data
// Name : Sequence Sort ( Standard Sort )
// Best : n
// Average : n²
// Worst : n²
// Memory : n
// Stable : Yes

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Sort
{
    public class SortModeSequence : SortModeBase
    {
        public override List<T> CompareRoutine<T>(List<T> sortList, SortCenter.delCompareFunction<T> func)
        {
            for(int i=0;i<sortList.Count;i++)
            {
                for(int j= i;j<sortList.Count;j++)
                {
                    if(func(sortList[i],sortList[j]))
                    {
                        SwapList<T>(ref sortList, i, j);
                    }
                }
            }
            return sortList;
        }
    }
}