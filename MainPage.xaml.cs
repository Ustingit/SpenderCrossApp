using Spender.DataService;
using System.Diagnostics;

namespace Spender;

public partial class MainPage : ContentPage
{
	private readonly ISpendDataService _service;
	
	public MainPage(ISpendDataService service)
	{
		InitializeComponent();
		this._service = service;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();

		collectionView.ItemsSource = await _service.GetAllAsync();
		//collectionView.IsGrouped = true;
	}

	async void OnAddSpendClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("---> Add button clicked");
	}

	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		Debug.WriteLine("---> Select button clicked");
	}
}

