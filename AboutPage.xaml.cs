using System.Diagnostics;




namespace TasksIngrijitori;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}
    private void OnEmailUsClicked(object sender, EventArgs e)
    {
        var email = "mailto:laura.rusu@gmail.com";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(email)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    private void OnFacebookClicked(object sender, EventArgs e)
    {
        var url = "https://www.facebook.com/PetNannyCluj";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
   


}