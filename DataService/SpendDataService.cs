namespace Spender.DataService
{
	public class SpendDataService : ISpendDataService
	{
		private readonly HttpClient _client;

		public SpendDataService(HttpClient client)
		{
			this._client = client;
		}


	}
}
