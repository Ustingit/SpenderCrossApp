namespace Spender.DTO.Common.Grouping
{
	public class GroupDto<TKey, TItem>
	{
		public GroupDto()
		{
		}

		public GroupDto(IEnumerable<IGrouping<TKey, TItem>> data)
		{
			Items = data.Select(x => new GroupedItems<TKey, TItem>(x.Key, x.ToList())).ToList();
		}

		public GroupDto(IEnumerable<TItem> data, Func<TItem, TKey> getter)
		{
			Items = data.GroupBy(getter).Select(x => new GroupedItems<TKey, TItem>(x.Key, x.ToList())).ToList();
		}

		public List<GroupedItems<TKey, TItem>> Items { get; private set; }
	}
}
