using System.ComponentModel;

namespace Spender.Models
{
	public class Spend : INotifyPropertyChanged
	{
		int _id;

		string _description;

		decimal _amount;

		SpendDirection _direction;

		DateTime _date;

		int _user;

		int _type;

		int? _subType;

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

		public SpendDirection Direction
		{
			get => _direction;
			set
			{
				if (_direction?.Value == value?.Value) return;

				_direction = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Direction)));
			}
		}

		public decimal Amount
		{
			get => _amount;
			set
			{
				if (_amount == value) return;

				_amount = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Amount)));
			}
		}

		public DateTime Date
		{
			get => _date;
			set
			{
				if (_date == value) return;

				_date = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
			}
		}

		public int Type
		{
			get => _type;
			set
			{
				if (_type == value) return;

				_type = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
			}
		}

		public int? SubType
		{
			get => _subType;
			set
			{
				if (_subType == value) return;

				_subType = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubType)));
			}
		}

		public int User
		{
			get => _user;
			set
			{
				if (_user == value) return;

				_user = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
