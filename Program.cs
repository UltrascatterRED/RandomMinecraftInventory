namespace RandomMinecraftInventory
{
	internal class Program
	{
		// Minecraft-API request all items:
		// https://minecraft-api.vercel.app/api/items
		static void Main(string[] args)
		{
			// Initialize HTTP Client, request all JSON item objects from API, parse into list of Item objects
			APIUtils.InitializeClient();
			var itemsTask = ItemProcessor.LoadItem("https://minecraft-api.vercel.app/api/items");
			List<Item> items = itemsTask.Result;
			Inventory inventory = new Inventory();
			bool exit = false;
			while (!exit)
			{
				Console.Clear();
				DisplayMainMenu();
				int userInput = PromptAndValidateInput(6);
				switch (userInput)
				{
					case 1:
						inventory = GenerateInventory(items);
						Console.WriteLine();
						Console.WriteLine("New inventory generated!");
						Console.WriteLine();
						Console.WriteLine("Press [ENTER] to continue");
						Console.ReadLine();
						break;
					case 2:
						Console.Write(inventory.SummaryString());
						Console.WriteLine();
						Console.WriteLine("Press [ENTER] to continue");
						Console.ReadLine();
						break;
					case 3:
						Console.Write(inventory.DetailedString());
                        Console.WriteLine();
                        Console.WriteLine("Press [ENTER] to continue");
						Console.ReadLine();
						break;
					case 4:
                        Console.WriteLine();
						Console.Write("Enter an item namespace id: ");
						string searchTerm = Console.ReadLine();
						bool found = false;
						Console.WriteLine();
						foreach (Item item in items)
						{
							if (searchTerm.Equals(item.NamespacedId))
							{
								found = true;
                                Console.Write(item.ToString());
								break;
                            }
						}
						if(!found) Console.WriteLine($"Item '{searchTerm}' does not exist.");
						Console.WriteLine();
						Console.WriteLine("Press [ENTER] to continue");
						Console.ReadLine();
						break;
					case 5:
						DisplayAppTutorial();
						Console.WriteLine();
						Console.WriteLine("Press [ENTER] to continue");
						Console.ReadLine();
						break;
					case 6:
						exit = true;
						break;
					default:
						continue;
				}
			}

		}
		public static void DisplayMainMenu()
		{
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write
			(
				"+------------------------------------------+\n" +
				"|   Minecraft Random Inventory Generator   |\n" +
				"+------------------------------------------+\n"
			);
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;

			Console.WriteLine("[1] Generate New Inventory");
			Console.WriteLine("[2] View Inventory (concise)");
			Console.WriteLine("[3] View Inventory (detailed)");
            Console.WriteLine("[4] Look Up Item Info");
            Console.WriteLine("[5] How To Use This App");
            Console.WriteLine("[6] Exit");
        }
		public static void DisplayAppTutorial()
		{
			Console.Write
			(
				"This app is pretty simple, and as such, uses simple commands.\n\n" +
				"The commands are as follows:\n" +
				"<1-6>................Selects and executes the corresponding menu option (i.e. '3').\n" +
				"[ENTER]..............Post-command, backs out to the main menu.\n\n" +
				"When looking up items, enter the namespace id, NOT the in-game item name. Namespace ids are\n" +
				"typically similar to their corresponding in-game name and are expressed in snake case \n" +
				"(just_like_this).\n"
			);
		}
		public static Inventory GenerateInventory(List<Item> itemPool)
		{
			Random rand = new Random();
			Inventory inventory = new Inventory();
			// whole percentage from 0 - 100
			int emptyChance = 33;

			for(int i = 0; i < inventory.Slots.Length; i++)
			{
				int emptyRoll = rand.Next(0,1000);
				if(emptyRoll > emptyChance * 10)
				{
					Item selectedItem = itemPool.ElementAt(rand.Next(0, itemPool.Count() - 1));
					inventory.Slots[i] = new InventorySlot(selectedItem, rand.Next(1, selectedItem.StackSize));
				}
			}
			return inventory;
		}
		/// <summary>
		/// Prompts the user for an input command and subsequently validates it.
		/// </summary>
		/// <param name="menuChoiceQty">
		/// The number of menu choices available at the time of method call.
		/// </param>
		/// <returns>The user's choice as an integer, or -1 if unsuccessful.</returns>
		public static int PromptAndValidateInput(int menuChoiceQty)
		{
			Console.WriteLine();
			Console.Write(">>> ");
			int origCol = Console.CursorLeft;
			int origRow = Console.CursorTop;
			try
			{
				int userInput = int.Parse(Console.ReadLine());
				if (userInput < 1 || userInput > menuChoiceQty)
				{
					
					Console.SetCursorPosition(0, Console.WindowHeight - 5);
					Console.Write("Invalid Menu Choice. Press [ENTER] to continue");
					Console.SetCursorPosition(origCol, origRow);
					Console.ReadLine();
					return -1;
				}
				return userInput;
            }
			catch
			{
				Console.SetCursorPosition(0, Console.WindowHeight - 5);
				Console.Write("Invalid Menu Choice. Press [ENTER] to continue");
				Console.SetCursorPosition(origCol, origRow);
				Console.ReadLine();
				return -1;
			}
		}
	}
}
