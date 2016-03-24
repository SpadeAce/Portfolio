using UnityEngine;
using System.Collections;

namespace Spade.Item
{
    public class GameItem
    {
        protected BaseItem item;
        
        public GameItem(BaseItem item)
        {
            this.item = item;
        }

        public static GameItem CreateItem(BaseItem item)
        {
            return new GameItem(item);
        }
    }
}