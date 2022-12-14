using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            DateTime date1 = DateTime.Parse(Console.ReadLine());
            DateTime date2 = DateTime.Parse(Console.ReadLine());

            DateModifier dates = new DateModifier(date1, date2);

            Console.WriteLine(dates.DaysBetweenDates());
        }
    }
}