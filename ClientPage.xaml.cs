using TasksIngrijitori.Models;
using Plugin.LocalNotification;

namespace TasksIngrijitori;

public partial class ClientPage : ContentPage
{
    public ClientPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var apartament = (Client)BindingContext;
        await App.Database.SaveShopAsync(apartament);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var apartament = (Client)BindingContext;
        await App.Database.DeleteShopAsync(apartament);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var apartament = (Client)BindingContext;
        var address = apartament.Adress; 
        var locations = await Geocoding.GetLocationsAsync(address);
        var options = new MapLaunchOptions { Name = "Clientul meu favorit" };
        var location = locations?.FirstOrDefault();
        var myLocation = await Geolocation.GetLocationAsync();
        
        
        var distance = myLocation.CalculateDistance(location, DistanceUnits.Kilometers);
        if (distance < 4)
        {
            var request = new NotificationRequest
            {
                Title = "Ai de reparat ceva in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule { NotifyTime = DateTime.Now.AddSeconds(1) }
            };
            LocalNotificationCenter.Current.Show(request);
        
    }
        await Map.OpenAsync(location, options);
    }
}