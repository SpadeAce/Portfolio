﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Spade.Item
{
    public class GreatBucket : BaseBucket
    {
        Dictionary<int, SampleItem> list = new Dictionary<int, SampleItem>();
        
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
            if (list.ContainsKey(index))
            {
                list.Remove(index);
            }
        }

        public override void Clear()
        {
            list.Clear();
        }

        public override void OnUpdateItem(BaseItem item)
        {
            if (!CheckType(item.Type)) return;

            if (list.ContainsKey(item.ID))
                list[item.ID] = new SampleItem(item);
            else
                list.Add(item.ID, new SampleItem(item));
        }
        public override void OnUpdateLocker(Locker locker)
        {
            foreach (LockerItem litem in locker.weapon_map.Values)
            {
                BaseItem bitem = ConvertItem(litem);

                if (list.ContainsKey(bitem.ID))
                    list[bitem.ID] = new SampleItem(bitem);
                else
                    list.Add(bitem.ID, new SampleItem(bitem));
            }
        }
    }
}