using Spender.Models;
using System.Text;
using System.Text.Json;

namespace Spender.DataService
{
	public class SpendDataService : ISpendDataService
	{
		private readonly HttpClient _client;
		private readonly string _baseAddress;
		private readonly Uri _url;
		private readonly JsonSerializerOptions _jsonOptions;

		public SpendDataService(HttpClient client)
		{
			this._client = client;
			_baseAddress = DeviceInfo.Platform == DevicePlatform.Android
				? "http://10.0.2.2:15423"
				: "https://localhost:44322";

			_url = new Uri($"{_baseAddress}/Spent");
			_jsonOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
			{
				System.Diagnostics.Debug.WriteLine($"---> No internet connection during deleting item with id: {id} !");
				return false;
			}

			try
			{
				HttpResponseMessage response = await _client.DeleteAsync($"{_url}/delete?id={id}");

				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					return JsonSerializer.Deserialize<bool>(content);
				}
				else
				{
					System.Diagnostics.Debug.WriteLine($"---> Non http 2xx response during deleting item with id: {id} !");
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"---> Exception during deleting item with id: {id} : {ex.Message}, {ex.StackTrace}!");
				return false;
			}

			return true;
		}

		public async Task<List<Spend>> GetAllAsync()
		{
			var spends = new List<Spend>();

			if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
			{
				System.Diagnostics.Debug.WriteLine("---> No internet connection during fetching items!!");
				return spends;
			}

			try
			{
				HttpResponseMessage response = await _client.GetAsync($"{_url}/get");
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					spends = JsonSerializer.Deserialize<List<Spend>>(content, _jsonOptions);
				}
				else
				{
					System.Diagnostics.Debug.WriteLine("---> Non http 2xx response during fetching items!!");
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"---> Exception during fetching items: {ex.Message}, {ex.StackTrace}!");

				return new List<Spend>()
				{
					new Spend
					{
						Id = 1,
						Description = "groceries",
						Amount = 16,
						Date = DateTime.Now,
						Direction = SpendDirection.OutCome,
						Type = 1,
						SubType = 3,
						User = 0
					},
					new Spend
					{
						Id = 2,
						Description = "transport",
						Amount = 4,
						Date = DateTime.Now,
						Direction = SpendDirection.OutCome,
						Type = 1,
						SubType = 4,
						User = 0
					}
				};
			}

			return new List<Spend>()
				{
					new Spend
					{
						Id = 1,
						Description = "groceries",
						Amount = 16,
						Date = DateTime.Now,
						Direction = SpendDirection.OutCome,
						Type = 1,
						SubType = 3,
						User = 0
					},
					new Spend
					{
						Id = 2,
						Description = "transport",
						Amount = 4,
						Date = DateTime.Now,
						Direction = SpendDirection.OutCome,
						Type = 1,
						SubType = 4,
						User = 0
					}
				};
		}

		public async Task<Spend> UpdateOrCreateAsync(Spend spend)
		{
			if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
			{
				System.Diagnostics.Debug.WriteLine($"---> No internet connection during updating item with id: {spend.Id} !");
				return null;
			}

			try
			{
				var spendAsJson = JsonSerializer.Serialize<Spend>(spend, _jsonOptions);
				HttpResponseMessage response = await _client.PostAsync($"{_url}/creatOrUpdate", new StringContent(spendAsJson, Encoding.UTF8, "application/json"));

				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					return JsonSerializer.Deserialize<Spend>(content, _jsonOptions);
				}
				else
				{
					System.Diagnostics.Debug.WriteLine($"---> Non http 2xx response during updating item with id: {spend.Id} !");
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"---> Exception during updating item with id: {spend.Id} : {ex.Message}, {ex.StackTrace}!");
			}

			return null;
		}
	}
}
