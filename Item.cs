namespace RandomMinecraftInventory
{
	public class Item
	{
		public string Name { get; set; }
		public string NamespacedId { get; set; }
		public string Description { get; set; }
		public int StackSize { get; set; }
		public bool Renewable { get; set; }
		public Item() 
		{ 
			Name = string.Empty;
			NamespacedId = string.Empty;
			Description = string.Empty;
			StackSize = 0;
			Renewable = false;
		}
		public Item(string name, string namespace_ID, string description, int stackSize, bool isRenewable)
		{
			Name = name;
			NamespacedId = namespace_ID;
			Description = description;
			StackSize = stackSize;
			Renewable = isRenewable;
		}
		public override string ToString()
		{
			return
				
				Name + " (" + NamespacedId + ")\n" +
				"--------------------------------------------------------------------\n" +
				Description + "\n\n" + 
				"Max Stack: " + StackSize + "\n" +
				"Renewable: " + Renewable + "\n" +
				"--------------------------------------------------------------------\n"
			;
		}
	}
}
