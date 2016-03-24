using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Spade.Item
{
    public class LockerItem
    {
        public long id;
        public int base_item_id;
        public int type;
        public int stack;
        public string status;
        public int exp;
        public bool is_deleted;
    }

    public class Locker
    {
        public Dictionary<string, LockerItem> weapon_map = new Dictionary<string, LockerItem>();
        public Dictionary<string, LockerItem> costume_map = new Dictionary<string, LockerItem>();
        public Dictionary<string, LockerItem> extra_map = new Dictionary<string, LockerItem>();
    }
}