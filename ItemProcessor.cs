namespace RandomMinecraftInventory
{
	public static class ItemProcessor
	{
		public static async Task<List<Item>> LoadItem(string url)
		{
			HttpResponseMessage response = await APIUtils.ApiClient.GetAsync(url);

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
