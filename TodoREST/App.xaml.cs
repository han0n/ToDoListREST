using TodoREST;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoREST
{
	public partial class App : Application
	{
		public static TodoItemManager TodoManager { get; private set; }

		public App ()
		{
			Device.SetFlags(new string[] { "Brush_Experimental" });
			InitializeComponent();
			TodoManager = new TodoItemManager (new RestService ());
			MainPage = new NavigationPage (new TodoListPage ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

