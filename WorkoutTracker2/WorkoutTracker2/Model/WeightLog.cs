using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;

namespace WorkoutTracker2.Model
{
    public class WeightLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double WeightChangeDouble { get; set; }
        public string WeightChange { get; set; }
        public string TextColor
        {
            get
            {
                if (WeightChangeDouble > 0)
                    return "#008000";
                else if (WeightChangeDouble < 0)
                    return "#ff0000";
                return "#000000";
            }
            set { }
        }

        public string MonthYear
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Date.Month) + " " + Date.Year;
            }
        }

    }
}
