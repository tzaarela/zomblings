using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [Serializable]
    public class InventoryItem
    {
        public int id;
        public ItemType itemType;
        public bool isSlotEmpty;

        public InventoryItem(ItemType itemType)
        {
            this.itemType = itemType;
        }
    }
}
