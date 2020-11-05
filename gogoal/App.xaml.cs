using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gogoal
{
    public partial class App : Application
    {
        static GogoalDatabase database;
        public static GogoalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GogoalDatabase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new GoGoal()) ;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
