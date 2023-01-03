using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = People.OrderByDescending(p => p.Age).ToList()[0];
            return oldest;
        }
    }
}
