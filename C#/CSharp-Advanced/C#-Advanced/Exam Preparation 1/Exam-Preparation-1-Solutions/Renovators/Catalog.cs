using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        // constructor
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        // fields
        private List<Renovator> renovators;

        // properties
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get; private set; }

        // Methods
        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Type == null
                || renovator.Name == String.Empty || renovator.Type == String.Empty)
            {
                return "Invalid renovator's information.";
            }

            if (NeededRenovators <= renovators.Count)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            Count++;
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(r => r.Name == name);
            if (renovator != null)
            {
                renovators.Remove(renovator);
                Count--;
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> toRemove = renovators.Where(r => r.Type == type).ToList();
            foreach (Renovator renovator in toRemove)
            {
                renovators.Remove(renovator);
                Count--;
            }
            return toRemove.Count;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(r => r.Name == name);
            if (renovator != null)
            {
                renovator.Hired = true;
                return renovator;
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report()
        {
            List<Renovator> availableRenovators = renovators
                .Where(r => r.Hired == false)
                .ToList();

            string output = $"Renovators available for Project {Project}:";
            foreach (Renovator renovator in availableRenovators)
            {
                output += $"\n{renovator}";
            }
            return output;
        }
    }
}