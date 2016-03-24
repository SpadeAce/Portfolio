using UnityEngine;
using System.Collections;

namespace Spade.Item
{
    public class SampleItem : GameItem
    {
        public int ID
        {
            get
            {
                return item.ID;
            }
        }

        public int ItemID
        {
            get
            {

                return item.ItemID;
            }
        }

        public string Name
        {
            get
            {
                return item.Name;
            }
        }

        public ItemType Type
        {
            get
            {
                return (ItemType)item.Type;
            }
        }

        public SampleItem(BaseItem item) : base(item)
        {

        }
    }
}