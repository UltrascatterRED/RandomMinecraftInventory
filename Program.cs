namespace RandomMinecraftInventory
{
	internal class Program
	{
		// https://minecraft-api.vercel.app/api/items?limit=1
		static void Main(string[] args)
		{
			APIUtils.InitializeClient();
			var testItem = ItemProcessor.LoadItem("https://minecraft-api.vercel.app/api/items");
			foreach (var item in testItem.Result)
			{
				Console.WriteLine(item.ToString());
			}
			
			//MainMenu();
		}
		public static void MainMenu()
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
			// extra options (if time allows)
            // Console.WriteLine("[4] Save Inventory To File");
            // Console.WriteLine("[5] Load Inventory From File");
			// end extra options
            Console.WriteLine("[4] How To Use This App");
            Console.WriteLine("[5] Exit");
            Console.WriteLine();
			Console.Write(">>> ");
        }
		public static void AppTutorial()
		{
			Console.Write
			(
				"This app is pretty simple, and as such, uses simple commands.\n" +
				"The commands are as follows:\n" +
				"<0-9>..............Selects and executes the corresponding menu option (i.e. '3')." +
				"<B/b>..............Backs out to the previous menu. Case-insensitive."
			);
			Console.WriteLine();
			Console.Write(">>> ");
		}
		// public static Inventory GenerateInventory()
		// public static bool PromptAndValidateInput()
	}
}
