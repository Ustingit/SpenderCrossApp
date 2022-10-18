using System.Text.Json.Serialization;

namespace Spender.Models.Common
{
	public class IdTextPair
	{
		public static IdTextPair Create(int id, string name, bool selected = false, int order = 0)
		{
			return new IdTextPair(id, name, selected, order);
		}

		public IdTextPair() { }

		public IdTextPair(int id, string name, bool selected = false, int order = 0)
		{
			Id = id;
			Name = name;
			Selected = selected;
			Order = order;
		}

		[JsonPropertyName(nameof(Id))]
		public int Id { get; set; }

		[JsonPropertyName(nameof(Name))]
		public string Name { get; set; }

		[JsonPropertyName(nameof(Selected))]
		public bool Selected { get; set; } = false;

		[JsonPropertyName(nameof(Order))]
		public int Order { get; set; } = 0;
	}
}
