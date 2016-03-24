using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Spade.Item
{
    public class Inventory : Immortal<Inventory>
    {
        Dictionary<string, BaseBucket> BucketList;

        public Inventory()
        {
            Initialize();
        }

        public void Initialize()
        {
            BucketList = BucketGenerator.Generate();
        }

        public void UpdateLocker(Locker locker)
        {
            foreach(BaseBucket bucket in BucketList.Values)
            {
                bucket.OnUpdateLocker(locker);
            }
        }

        public void UpdateItem(BaseItem item)
        {
            foreach (BaseBucket bucket in BucketList.Values)
            {
                bucket.OnUpdateItem(item);
            }
        }

        public void RemoveItem(int index)
        {
            foreach (BaseBucket bucket in BucketList.Values)
            {
                bucket.RemoveItem(index);
            }
        }

        public void ClearAllBucket()
        {
            foreach (BaseBucket bucket in BucketList.Values)
            {
                bucket.Clear();
            }
        }

        public static T GetBucket<T>() where T : BaseBucket
        {
            string className = typeof(T).Name;

            if (instance.BucketList == null || !instance.BucketList.ContainsKey(className))
                return null;

            return instance.BucketList[className] as T;
        }
    }
}