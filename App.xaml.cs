using System;
using TasksIngrijitori.Data;
using System.IO;
namespace TasksIngrijitori;

public partial class App : Application
{
    static JobsDatabase database;
    public static JobsDatabase Database 
	{
		get 
		{
			if (database == null) 
			{ 
				database = new JobsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Jobs.db3")); 
			}
			return database;
		} 
	}
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
