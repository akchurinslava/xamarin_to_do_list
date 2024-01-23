using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin_to_do_list
{
    public partial class App : Application
    {

        public const string dbname = "tododb.db";
        public static to_do_repository database;

        public static to_do_repository Database
        {
            get
            {
                if (database == null)
                {
                    database = new to_do_repository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbname));
                }
                return database;
            }
        }


        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

