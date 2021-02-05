using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
	[Serializable]
	public class Inventory
	{
		public InventoryItem[] blockers;
		public InventoryItem[] teleporters;
		public InventoryItem[] empowers;

		private List<InventoryItem[]> items;
		private ItemType[] itemTypes;

		public Inventory(int blockerCount, int teleporterCount, int empowerCount)
		{
			itemTypes = new ItemType[]
			{
				ItemType.Blocker,
				ItemType.Teleporter,
				ItemType.Empower
			};

			items = new List<InventoryItem[]>();
			items.Add(new InventoryItem[blockerCount]);
			items.Add(new InventoryItem[teleporterCount]);
			items.Add(new InventoryItem[empowerCount]);

			FillInventory();
		}

		public void FillInventory()
        {
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < items[i].Count(); j++)
                {
					items[i][j] = new InventoryItem(itemTypes[i]);
                }
            }
        }

		public int GetItemCount(ItemType itemType)
        {
			return items
				.FirstOrDefault(x => x.Any(y => y.itemType == itemType))
				.Where(x => !x.isSlotEmpty).ToArray().Length;
		}

		public void AddToInventory(ItemType itemType)
        {
			var droppers = items.FirstOrDefault(x => x.Any(y => y.itemType == itemType));

			items.ForEach(test => Console.WriteLine(test.Length));

            for (int i = 0; i < droppers.Length; i++)
            {
				if (droppers[i].isSlotEmpty)
                {
					droppers[i] = new InventoryItem(itemType);
					break;
                }
			}
        }

        public InventoryItem TakeFromInventory(ItemType itemType)
        {
			var droppers = items.FirstOrDefault(x => x.Any(y => y.itemType == itemType));
			var dropper = droppers.FirstOrDefault(x => !x.isSlotEmpty);

			if(dropper != null)
				dropper.isSlotEmpty = true;

			return dropper;
		}
    }
}