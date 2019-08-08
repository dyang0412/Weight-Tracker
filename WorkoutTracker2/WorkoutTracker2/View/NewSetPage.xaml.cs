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
    public partial class NewSetPage : ContentPage
    {
        int ExerciseId;
        public NewSetPage(int ExerciseId)
        {
            InitializeComponent();
            this.ExerciseId = ExerciseId;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var set = (Set)BindingContext;
            set.ExerciseId = this.ExerciseId;

            await App.Database.SaveSetAsync(set);
            await Navigation.PopAsync();
        }
    }
}