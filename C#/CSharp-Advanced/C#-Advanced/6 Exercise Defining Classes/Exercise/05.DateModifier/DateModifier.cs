using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class DateModifier
    {
        public DateModifier(DateTime date1, DateTime date2)
        {
            FirstDate = date1;
            SecondDate = date2;
        }

        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        public double DaysBetweenDates()
        {
            TimeSpan daysBetween = FirstDate - SecondDate;
            return Math.Abs(daysBetween.TotalDays);
        }
    }
}
