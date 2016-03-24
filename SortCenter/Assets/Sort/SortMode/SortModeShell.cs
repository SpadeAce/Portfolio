// Sorting Data
// Name : Shell Sort
// Best : n
// Average : (n log² n) or (n1½)
// Worst : Depend on gap sequence, best known is (n log² n)
// Memory : 1
// Stable : No

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Sort
{
    public class SortModeShell : SortModeBase
    {
        public override List<T> CompareRoutine<T>(List<T> sortList, SortCenter.delCompareFunction<T> func)
        {
            for (int step = sortList.Count / 2; step > 0; step /= 2)
            {
                for (int i = 0; i < step; i++)
                {
                    Insertion<T>(ref sortList, i, step, func);
                }
            }
            return sortList;
        }

        private void Insertion<T>(ref List<T> sortList, int point, int step, SortCenter.delCompareFunction<T> func)
        {
            for (int i = step; i < sortList.Count - point; i += step)
            {
                for (int j = i; j > 0; j -= step)
                {
                    if (func(sortList[point + j - step], sortList[point + j]))
                    {

                        SwapList<T>(ref sortList, point + j - step, point + j);
                    }
                    else
                        break;
                }
            }
        }
    }
}