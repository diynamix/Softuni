﻿namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Enums;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repair => (IReadOnlyCollection<IRepair>)repairs;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (IRepair repair in repairs)
            {
                sb.AppendLine($"  {repair}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
