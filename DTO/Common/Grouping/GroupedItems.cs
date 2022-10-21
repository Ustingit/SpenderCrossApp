namespace Spender.DTO.Common.Grouping
{
    public class GroupedItems<TKey, TItem>
    {
        public GroupedItems(TKey group, List<TItem> items)
        {
            Group = group;
            Items = items;
        }

        public TKey Group { get; private set; }

        public List<TItem> Items { get; private set; }
    }
}
