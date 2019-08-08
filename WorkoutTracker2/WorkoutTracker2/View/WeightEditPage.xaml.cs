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
    public partial class WeightEditPage : ContentPage
    {

        public WeightEditPage()
        {
            InitializeComponent();

            var weightLog = new WeightLog
            {
                Date = DateTime.Now,
                Weight = 0
            };

        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var weight = (WeightLog)BindingContext;

            await App.Database.SaveWeightAsync(weight);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var confirmation = await DisplayAlert("Delete", "Are you sure you want to delete?", "Delete", "Cancel");
            if (confirmation)
            {
                var weight = (WeightLog)BindingContext;
                await App.Database.DeleteWeightAsync(weight);
                await Navigation.PopAsync();
            }
        }
    }
}