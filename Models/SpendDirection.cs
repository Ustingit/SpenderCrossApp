using Ardalis.SmartEnum;
using Spender.Models.Common;

namespace Spender.Models
{
	public class SpendDirection : SmartEnum<SpendDirection>
	{
		public static readonly SpendDirection OutCome = new SpendDirection(nameof(OutCome), 0);
		public static readonly SpendDirection InCome = new SpendDirection(nameof(InCome), 1);

		public List<IdTextPair> Types { get; set; }
		public List<IdTextPairWithParent> SubTypes { get; set; }

		private SpendDirection(string name, int value) : base(name, value)
		{
			Types = new List<IdTextPair>(0);
			SubTypes = new List<IdTextPairWithParent>(0);
		}
	}
}
