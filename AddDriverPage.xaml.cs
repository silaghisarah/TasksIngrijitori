using TasksIngrijitori.Models;
namespace TasksIngrijitori;

public partial class AddClientPage : ContentPage
{
	public AddClientPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        VizualizareJob.ItemsSource = await App.Database.GetShopsAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientPage
        {
            BindingContext = new Client()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) { await Navigation.PushAsync(new ClientPage { BindingContext = e.SelectedItem as Client }); }
    }
}