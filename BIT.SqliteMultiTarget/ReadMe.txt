Notes

The current version of Sqlite included in this package is 1.1.12

Android:no setup required

UWP:no setup required

iOS:you need to execute SQLitePCL.Batteries_V2.Init() in your Application class and decorate the classs with the attribute [Preserve(typeof(SqliteConnection))]
		

    [Preserve(typeof(SqliteConnection))]
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
            //Initialize SQLite with the sqlite3 provider
            SQLitePCL.Batteries_V2.Init();

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
			UIApplication.Main(args, null, "AppDelegate");
		}
	}