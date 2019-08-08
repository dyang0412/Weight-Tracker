using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class WeightPage : ContentPage
    {
        public List<WeightLog> Weights;
        public List<WeightLog> SortedWeights;
        public List<List<WeightLog>> SortedWeightsGrouped;
        public ObservableCollection<GroupedWeightList> grouped;

        public WeightPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            Weights = await App.Database.GetWeightsAsync();
            SortedWeights = Weights.OrderByDescending(o => o.Date).ToList();
            grouped = new ObservableCollection<GroupedWeightList>();

            double weightchange;
            string weightchangeString;
            for (int i = 0; i < SortedWeights.Count() - 1; i++)
            {
                weightchange = SortedWeights[i].Weight - SortedWeights[i + 1].Weight;
                SortedWeights[i].WeightChangeDouble = weightchange;
                if (weightchange > 0)
                    weightchangeString = "+ " + weightchange.ToString() + " lbs";
                else if (weightchange < 0)
                    weightchangeString = "- " + Math.Abs(weightchange).ToString() + " lbs";
                else
                    weightchangeString = "";
                SortedWeights[i].WeightChange = weightchangeString;
            }

            SortedWeightsGrouped = SortedWeights
                .GroupBy(w => w.MonthYear)
                .Select(g => g.ToList())
                .ToList();

            grouped = processWeights(SortedWeightsGrouped);
            
            if(grouped != null)
                listView.ItemsSource = grouped;

        }

   

        private async void OnWeightAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewWeightPage
            {
                BindingContext = new WeightLog()
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            var item = args.SelectedItem as WeightLog;
            if (item == null)
                return;
            
           
            await Navigation.PushAsync(new WeightEditPage {
                BindingContext = args.SelectedItem as WeightLog
            });

            // Manually deselect item.
            listView.SelectedItem = null;
        }

        public ObservableCollection<GroupedWeightList> processWeights(List<List<WeightLog>> weights)
        {
            ObservableCollection<GroupedWeightList> result = new ObservableCollection<GroupedWeightList>();
            foreach (var weightlist in weights)
            {
                string header = weightlist[0].MonthYear;
                var tempGroup = new GroupedWeightList() { Heading = header };
                double netChange = weightlist[0].Weight - weightlist[weightlist.Count-1].Weight;
                tempGroup.NetWeightChangeDouble = netChange;
                if(netChange != 0)
                    tempGroup.NetWeightChange = Math.Abs(netChange).ToString(); 

                if (netChange > 0)
                {
                    tempGroup.NetWeightChange = "+ " + tempGroup.NetWeightChange + " lbs";
                }
                    
                else if(netChange < 0)
                {
                    tempGroup.NetWeightChange = "- " + tempGroup.NetWeightChange + " lbs";
                }
                    
                foreach (var weight in weightlist)
                {
                    tempGroup.Add(weight);
                }
                result.Add(tempGroup);
            }
            return result;
        }
    }
}