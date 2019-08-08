using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorkoutTracker2.View;
using WorkoutTracker2.Data;
using System.IO;

namespace WorkoutTracker2
{
    public partial class App : Application
    {
        static WorkoutDatabase database;
        
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTI1NzMzQDMxMzcyZTMyMmUzMGgvbVNjMGdqcTJ1cU1mUm5ZSjBhSXBjU2tpcWNzWGl4RDBpV0RiWER6d3M9");
            InitializeComponent();
            MainPage = new MainPage();
        }

        public static WorkoutDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new WorkoutDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WorkoutSQLite.db3"));
                    //database.SaveWorkoutAsync(new Model.Workout { Id = 1, Name = "Workout 1", Description = "Yer" }) ;
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }
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
