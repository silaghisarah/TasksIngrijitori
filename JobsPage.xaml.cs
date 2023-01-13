using TasksIngrijitori.Models;
namespace TasksIngrijitori;

public partial class PaginaJobs : ContentPage
{
	public PaginaJobs()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var slist = (ListaJobs)BindingContext;
		slist.Date = DateTime.UtcNow;
        Client selectedClient = (AlegeClient.SelectedItem as Client);
		slist.ClientID = selectedClient.ID;
        await App.Database.SaveShopListAsync(slist);
		await Navigation.PopAsync(); 
	}
    async void OnDeleteButtonClicked(object sender, EventArgs e) 
	{
		var slist = (ListaJobs)BindingContext;
		await App.Database.DeleteShopListAsync(slist);
		await Navigation.PopAsync();
	}
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PredifinedJobs((ListaJobs)this.BindingContext)
		{ 
			BindingContext = new Job() 
		});
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetShopsAsync();
		AlegeClient.ItemsSource = (System.Collections.IList)items;
        AlegeClient.ItemDisplayBinding = new Binding("DetaliiClient");
        var shopl = (ListaJobs)BindingContext;
        VizualizareaJobs.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
}