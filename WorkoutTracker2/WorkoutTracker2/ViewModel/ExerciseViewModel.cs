using System;
using System.Collections.Generic;
using System.Text;
using WorkoutTracker2.Model;

namespace WorkoutTracker2.ViewModel
{
    public class ExerciseViewModel : BaseViewModel
    {
        public Workout Workout { get; set; }
        public ExerciseViewModel(Workout workout = null)
        {
            Workout = workout;
        }
    }
}
