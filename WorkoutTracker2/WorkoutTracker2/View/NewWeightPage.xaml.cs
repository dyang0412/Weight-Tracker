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
    public partial class NewWeightPage : ContentPage
    {
        
        public NewWeightPage()
        {
            InitializeComponent();
            DatePicker.Date = DateTime.Now;
        }
   
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var weight = (WeightLog)BindingContext;
            weight.Date = DatePicker.Date;
            await App.Database.SaveWeightAsync(weight);
            await Navigation.PopAsync();
        }

    }
}