using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMinecraftInventory
{
	public class InventorySlot
	{
		public Item? Item { get; private set; }
		public int Quantity { get; set; }

		public InventorySlot()
		{
			Item = null;
			Quantity = 0;
		}
		public InventorySlot(Item item, int quantity)
		{
			Item = item;
			// clamps quantity between 0 (default) and the maximum stack size of the given item (1, 16, 64, etc)
			if(quantity < 0)
			{
				Quantity = 0;
			}
			else if (quantity > item.StackSize)
			{
				Quantity = item.StackSize;
			}
			else
			{
				Quantity = quantity;
			}
		}
		public override string ToString()
		{
			if (Item == null)
			{
				return "empty";
			}
			return 
				Item.Name + " (" + Quantity + ")";
			;
		}
		public string FormatQuantityForDisplay()
		{
			if (Quantity <= 0)
			{
				return "  ";
			}
			else if (Quantity > 0 && Quantity < 10)
			{
				return $" {Quantity}";
			}
			else
			{
				return $"{Quantity}";
			}
		}
	}
}
