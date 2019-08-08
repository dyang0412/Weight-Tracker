using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace WorkoutTracker2.Model
{
    public class Exercise
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Workout))]
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        [ManyToOne]
        public Workout Workout { get; set; }

        [TextBlob("ListOfSets")]
        public List<Set> ListOfSets { get; set; }
    }
}
