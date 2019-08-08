using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutTracker2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPageWorkout : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupPageWorkout()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            Workout workout = new Workout
            {
                Name = nameEntry.Text
            };
            await App.Database.SaveWorkoutAsync(workout);
            await PopupNavigation.Instance.PopAsync(true);
        }

        void OnCancelClicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }
    }
}