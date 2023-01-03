using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    internal class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (CheckStat(value, nameof(Endurance)))
                {
                    endurance = value;
                }
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (CheckStat(value, nameof(Sprint)))
                {
                    sprint = value;
                }
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (CheckStat(value, nameof(Dribble)))
                {
                    dribble = value;
                }
            }
        }

        public int Passing
        {
            get { return passing; }
            private set
            {
                if (CheckStat(value, nameof(Passing)))
                {
                    passing = value;
                }
            }
        }

        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (CheckStat(value, nameof(Shooting)))
                {
                    shooting = value;

                }
            }
        }

        private bool CheckStat(int number, string statName)
        {
            if (number < 0 || number > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
            return true;
        }
    }
}
