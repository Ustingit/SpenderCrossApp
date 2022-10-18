using System.ComponentModel;

namespace Spender.Models
{
	public class Spend : INotifyPropertyChanged
	{
		int _id;

		string _description;

		SpendDirection _direction;

		public int Id
		{
			get => _id;
			set
			{
				if (_id == value) return;

				_id = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
			}
		}

		public string Description
		{
			get => _description;
			set
			{
				if (_description == value) return;

				_description = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
			}
		}

		public SpendDirection Type
		{
			get => _direction;
			set
			{
				if (_direction.Value == value.Value) return;

				_direction = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
