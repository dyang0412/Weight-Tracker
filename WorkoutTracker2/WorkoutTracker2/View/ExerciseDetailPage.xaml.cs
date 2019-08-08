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
    public partial class ExerciseDetailPage : ContentPage
    {
        List<Set> sets;
        public ExerciseDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var Exercise = (Exercise)BindingContext;
            sets = await App.Database.GetSetsByExerciseAsync(Exercise.Id);
            listView.ItemsSource = sets;

        }

        async void OnSetAdded(object sender, EventArgs e)
        {
            var Exercise = (Exercise)BindingContext;
            await Navigation.PushAsync(new NewSetPage(Exercise.Id)
            {
                BindingContext = new Set()
            });
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var exercise = (Exercise)BindingContext;
            await App.Database.DeleteExerciseAsync(exercise);
            await Navigation.PopAsync();
        }
    }
}