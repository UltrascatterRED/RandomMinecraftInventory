using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMinecraftInventory
{
	internal class Item
	{
		public string Name { get; set; }
		public string Namespace_ID { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public int StackSize { get; set; }
		public bool IsRenewable { get; set; }
		public Item() 
		{ 
			Name = string.Empty;
			Namespace_ID = string.Empty;
			Description = string.Empty;
			ImagePath = string.Empty;
			StackSize = 0;
			IsRenewable = false;
		}
		public Item(string name, string namespace_ID, string description, string imagePath, int stackSize, bool isRenewable)
		{
			Name = name;
			Namespace_ID = namespace_ID;
			Description = description;
			ImagePath = imagePath;
			StackSize = stackSize;
			IsRenewable = isRenewable;
		}
	}
}
