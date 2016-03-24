using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Spade.Item
{
    public abstract class BaseBucket
    {
        protected int[] checklist;

        public abstract T GetItem<T>(int index) where T : GameItem;
        public abstract void RemoveItem(int index);
        public abstract void Clear();

        public abstract void OnUpdateLocker(Locker locker);
        public abstract void OnUpdateItem(BaseItem item);

        protected bool CheckType(int type)
        {
            for (int i = 0; i < checklist.Length; i++)
            {
                if (checklist[i] == type)
                    return true;
            }

            return false;
        }

        protected BaseItem ConvertItem(LockerItem litem)
        {
            BaseItem bitem = new BaseItem();
            bitem.ID = (int)litem.id;
            bitem.ItemID = litem.base_item_id;
            bitem.Name = litem.status;
            bitem.Type = litem.type;
            return bitem;
        }
    }
}