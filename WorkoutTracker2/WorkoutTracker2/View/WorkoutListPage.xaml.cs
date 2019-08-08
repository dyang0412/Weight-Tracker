using Rg.Plugins.Popup.Services;
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
    public partial class WorkoutListPage : ContentPage
    {
        
        public WorkoutListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetWorkoutsAsync();
            
        }

        async void OnWorkoutAdded(object sender, EventArgs e)
        {
            //PopupNavigation.Instance.PushAsync(new PopupPageWorkout());
            
            await Navigation.PushAsync(new NewWorkoutPage
            {
                BindingContext = new Workout()
            });
            
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Workout;
            if (item == null)
                return;

            await Navigation.PushAsync(new WorkoutDetailPage
            {
                BindingContext = args.SelectedItem as Workout
            });

            // Manually deselect item.
            listView.SelectedItem = null;
        }
    }
}