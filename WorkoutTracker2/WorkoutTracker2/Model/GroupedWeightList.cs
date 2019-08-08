using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace WorkoutTracker2.Model
{
    public class GroupedWeightList : ObservableCollection<WeightLog>
    {
        public string Heading { get; set; }
        public double NetWeightChangeDouble { get; set; }
        public string NetWeightChange { get; set; }
        public string TextColor
        {
            get
            {
                if (NetWeightChangeDouble > 0)
                    return "#008000";
                else if (NetWeightChangeDouble < 0)
                    return "#ff0000";
                return "#000000";
            }
            set { }
        }
    }
}
