using Ardalis.SmartEnum;

namespace Spender.Models.Types
{
	public class SpendType : SmartEnum<SpendType>
	{
		public static readonly SpendType OutCome = new SpendType(nameof(OutCome), 0);
		public static readonly SpendType InCome = new SpendType(nameof(InCome), 1);

		private SpendType(string name, int value) : base(name, value)
		{
		}
	}
}
