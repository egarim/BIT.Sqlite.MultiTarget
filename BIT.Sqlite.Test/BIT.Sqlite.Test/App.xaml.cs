using DevExpress.Xpo.DB;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using DevExpress.Xpo;
using System.Diagnostics;

namespace BIT.Sqlite.Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            try
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);



                var filePath = Path.Combine(documentsPath, "XpoXamarin.db");
                string connectionString = SQLiteConnectionProvider.GetConnectionString(filePath) + ";Cache=Shared;";





                XpoHelper.InitXpo(connectionString);



                var UoW = XpoHelper.CreateUnitOfWork();

                var count = UoW.Query<Item>().Count();
                MainPage = new MainPage(filePath, count);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                throw exception;
            }
            
          




        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
