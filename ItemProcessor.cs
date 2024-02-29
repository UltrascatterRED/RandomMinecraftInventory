namespace RandomMinecraftInventory
{
	public static class ItemProcessor
	{
		public static async Task<List<Item>> LoadItem(string url)
		{
			Console.WriteLine("Item loading...");
			HttpResponseMessage response = await APIUtils.ApiClient.GetAsync(url);

			//debug
			Console.WriteLine("Response received!");
			Console.WriteLine($"{response.Content}");
			//end debug
			if (response.IsSuccessStatusCode)
			{
				List<Item> items = await response.Content.ReadAsAsync<List<Item>>();
				return items;
			}
			else
			{
				throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
