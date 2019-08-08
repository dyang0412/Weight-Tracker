using System;
using System.Collections.Generic;
using System.Text;
using WorkoutTracker2.Model;

namespace WorkoutTracker2.ViewModel
{
    public class WeightViewModel : BaseViewModel
    {
        public WeightLog WeightLog { get; set; }
        public WeightViewModel(WeightLog weightlog = null)
        {
            WeightLog = weightlog;
        }
    }
}
