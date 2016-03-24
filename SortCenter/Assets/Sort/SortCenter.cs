using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Sort
{
    public class SortCenter : Immortal<SortCenter>
    {
        public delegate bool delCompareFunction<T>(T compare_1, T compare_2);

        public List<T> SyncOriginalSorting<Sort, T>(List<T> sortList, delCompareFunction<T> func) where Sort : SortModeBase, new()
        {
            Sort SortObject = new Sort();

            return SortObject.CompareRoutine<T>(sortList, func);
        }

        public List<T> SyncCopySorting<Sort, T>(List<T> sortList, delCompareFunction<T> func) where Sort : SortModeBase, new()
        {
            Sort SortObject = new Sort();
            List<T> copyList = new List<T>(sortList);
            return SortObject.CompareRoutine<T>(copyList, func);
        }

        public List<T> ASyncSorting<Sort, T>(List<T> sortList, delCompareFunction<T> func) where Sort : SortModeBase, new()
        {
            // Not implemented
            Sort SortObject = new Sort();

            return SortObject.CompareRoutine<T>(sortList, func);
        }
    }
}