using System.Collections.ObjectModel;

namespace HikerManagementApp;

public partial class App : Application
{
	public ObservableCollection<Hike> HikeList;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
