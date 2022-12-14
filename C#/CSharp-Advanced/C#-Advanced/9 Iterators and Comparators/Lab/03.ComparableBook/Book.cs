using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }
        
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }

        public int CompareTo([AllowNull] Book other)
        {
            //if (other == null) return 1;
            int result = this.Year.CompareTo(other.Year);
            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }
            return result;
        }
    }
}
