namespace PersonInfo
{
    using System;

    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value)) { }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0) { }
                age = value;
            }
        }
    }
}
