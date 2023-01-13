using TasksIngrijitori.Models;

namespace TasksIngrijitori;

public partial class TaskListPage : ContentPage
{
	public TaskListPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
       VizualizareJob.ItemsSource = await App.Database.GetShopListsAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaJobs
        {
            BindingContext = new ListaJobs() 
        }); 
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)

    {
        if (e.SelectedItem != null) 
        {
            await Navigation.PushAsync(new PaginaJobs 
            {
                BindingContext = e.SelectedItem as ListaJobs 
            });
        }
    }
}