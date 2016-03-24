using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Sort
{
    public abstract class SortModeBase
    {
        public abstract List<T> CompareRoutine<T>(List<T> sortList, SortCenter.delCompareFunction<T> func);

        protected static void SwapList<T>(ref List<T> list, int left, int right)
        {
            T temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}