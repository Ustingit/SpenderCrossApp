using Spender.Models;

namespace Spender.DataService
{
	public interface ISpendDataService
	{
		Task<List<Spend>> GetAllAsync();

		Task<Spend> UpdateOrCreateAsync(Spend spend);

		Task<bool> DeleteAsync(int id);
	}
}
