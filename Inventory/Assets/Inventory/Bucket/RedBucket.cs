using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Spade.Item
{
    public class RedBucket : BaseBucket
    {
        Dictionary<int, SampleItem> list = new Dictionary<int, SampleItem>();
        
        public RedBucket()
        {
            checklist = new int[] { (int)ItemType.RED };
        }

        public override T GetItem<T>(int index)
        {
            if (list.ContainsKey(index))
                return list[index] as T;
            else
                return null;
        }

        public List<SampleItem> GetItemList()
        {
            return new List<SampleItem>(list.Values);
        }

        public override void RemoveItem(int index)
        {
            if(list.ContainsKey(index))
            {
                list.Remove(index);
            }
        }

        public override void Clear()
        {
            list.Clear();
        }

        public override void OnUpdateLocker(Locker locker)
        {
            foreach(LockerItem litem in locker.weapon_map.Values)
            {
                if (!CheckType(litem.type)) continue;

                BaseItem bitem = ConvertItem(litem);

                if (list.ContainsKey(bitem.ID))
                    list[bitem.ID] = new SampleItem(bitem);
                else
                    list.Add(bitem.ID, new SampleItem(bitem));
            }
        }

        public override void OnUpdateItem(BaseItem item)
        {
            if (!CheckType(item.Type)) return;

            if (list.ContainsKey(item.ID))
                list[item.ID] = new SampleItem(item);
            else
                list.Add(item.ID, new SampleItem(item));
        }

    }
}