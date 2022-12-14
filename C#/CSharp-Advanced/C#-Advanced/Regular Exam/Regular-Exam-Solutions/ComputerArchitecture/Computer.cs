using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            multiprocessor = new List<CPU>();
        }

        private List<CPU> multiprocessor;
        
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor {
            get
            {
                return multiprocessor;
            }
        }

        public int Count => multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Capacity > Count)
            {
                multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU cpu = multiprocessor.Find(cpu => cpu.Brand == brand);
            if (cpu != null)
            {
                multiprocessor.Remove(cpu);
                return true;
            }
            return false;
        }

        public CPU MostPowerful()
        {
            if (!multiprocessor.Any())
            {
                return null;
            }
            return multiprocessor.OrderByDescending(cpu => cpu.Frequency).First();
        }

        public CPU GetCPU(string brand)
        {
            if (!multiprocessor.Any(cpu => cpu.Brand == brand))
            {
                return null;
            }
            return multiprocessor.Find(cpu => cpu.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (CPU cpu in multiprocessor)
            {
                sb.AppendLine($"{cpu}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
