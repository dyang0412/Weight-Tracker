using System;
using System.Collections.Generic;
using System.Text;
using WorkoutTracker2.Model;

namespace WorkoutTracker2.ViewModel
{
    public class WorkoutDetailViewModel : BaseViewModel
    {
        public Workout Workout { get; set; }
        public WorkoutDetailViewModel(Workout workout = null)
        {
            Title = workout?.Name;
            Workout = workout;
        }
    }
}
