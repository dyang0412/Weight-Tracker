using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker2.Model;
using WorkoutTracker2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutTracker2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExercisePage : ContentPage
    {
        int WorkoutId;
        public NewExercisePage(int WorkoutId)
        {
            InitializeComponent();
            this.WorkoutId = WorkoutId;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var Exercise = (Exercise)BindingContext;
            Exercise.WorkoutId = this.WorkoutId;

            await App.Database.SaveExerciseAsync(Exercise);
            await Navigation.PopAsync();
        }
    }
}