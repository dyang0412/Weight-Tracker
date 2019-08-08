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
    public partial class WorkoutDetailPage : ContentPage
    {
        List<Exercise> exercises;
        public WorkoutDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var Workout = (Workout)BindingContext;
            exercises = await App.Database.GetExercisesByWorkoutAsync(Workout.Id);
            listView.ItemsSource = exercises;

        }

        async void OnExerciseAdded(object sender, EventArgs e)
        {
            var Workout = (Workout)BindingContext;
            await Navigation.PushAsync(new NewExercisePage(Workout.Id)
            {
                BindingContext = new Exercise()
            });
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var workout = (Workout)BindingContext;
            await App.Database.DeleteWorkoutAsync(workout);
            await Navigation.PopAsync();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Exercise;
            if (item == null)
                return;

            await Navigation.PushAsync(new ExerciseDetailPage
            {
                BindingContext = args.SelectedItem as Exercise
            });

            // Manually deselect item.
            listView.SelectedItem = null;
        }

    }
}