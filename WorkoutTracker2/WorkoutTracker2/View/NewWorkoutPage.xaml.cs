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
    public partial class NewWorkoutPage : ContentPage
    {
        public NewWorkoutPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var workout = (Workout)BindingContext;
            await App.Database.SaveWorkoutAsync(workout);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var workout = (Workout)BindingContext;
            await App.Database.DeleteWorkoutAsync(workout);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

       
    }
}