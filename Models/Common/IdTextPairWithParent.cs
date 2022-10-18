using System.Text.Json.Serialization;

namespace Spender.Models.Common
{
	public class IdTextPairWithParent : IdTextPair
	{
		public static IdTextPairWithParent Create(int id, string name, int parent, bool selected = false, int order = 0)
		{
			return new IdTextPairWithParent(id, name, parent, selected, order);
		}

		public IdTextPairWithParent() { }

		public IdTextPairWithParent(int id, string name, int parent, bool selected = false, int order = 0)
			: base(id, name, selected, order)
		{
			Parent = parent;
		}

		[JsonPropertyName(nameof(Parent))]
		public int Parent { get; set; }
	}
}
