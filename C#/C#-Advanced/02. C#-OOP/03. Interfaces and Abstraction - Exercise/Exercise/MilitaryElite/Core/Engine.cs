namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models;
    using Models.Contracts;
    using Models.Enums;
    using IO.Interfaces;

    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<ISoldier> allSoldiers;

        private Engine()
        {
            allSoldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            CreateSoldiers();
            PrintSoldiers();
        }

        private void CreateSoldiers()
        {
            string command;

            while ((command = reader.ReadLine()) != "End")
            {
                string[] args = command.Split(" ");

                string soldierType = args[0];
                int id = int.Parse(args[1]);
                string firstName = args[2];
                string lastName = args[3];

                ISoldier soldier;

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(args[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(args[4]);
                    ICollection<IPrivate> privates = FindPrivates(args);
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(args[4]);
                    string corpsText = args[5];

                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);
                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICollection<IRepair> repairs = CreateRepairs(args);
                    soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(args[4]);

                    string corpsText = args[5];
                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);
                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICollection<IMission> missions = CreateMissions(args);
                    soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(args[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                else
                {
                    continue;
                }

                allSoldiers.Add(soldier);
            }
        }

        private ICollection<IPrivate> FindPrivates(string[] cmdArgs)
        {
            int[] privateIds = cmdArgs.Skip(5).Select(int.Parse).ToArray();

            ICollection<IPrivate> privates = new HashSet<IPrivate>();

            foreach (int privateId in privateIds)
            {
                IPrivate currentPeivate = (IPrivate)allSoldiers.FirstOrDefault(s => s.Id == privateId);

                privates.Add(currentPeivate);
            }

            return privates;
        }

        private ICollection<IRepair> CreateRepairs(string[] cmdArgs)
        {
            string[] repairsInfo = cmdArgs.Skip(6).ToArray();

            ICollection<IRepair> repairs = new HashSet<IRepair>();

            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                string partName = repairsInfo[i];
                int hoursWorked = int.Parse(repairsInfo[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);

                repairs.Add(repair);
            }

            return repairs;
        }

        private ICollection<IMission> CreateMissions(string[] cmdArgs)
        {
            string[] missionInfo = cmdArgs.Skip(6).ToArray();

            ICollection<IMission> missions = new HashSet<IMission>();

            for (int i = 0; i < missionInfo.Length; i += 2)
            {
                string codeName = missionInfo[i];
                string stateText = missionInfo[i + 1];
                bool isStateValid = Enum.TryParse<State>(stateText, false, out State state);
                if (!isStateValid)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);

                missions.Add(mission);
            }

            return missions;
        }

        private void PrintSoldiers()
        {
            foreach (ISoldier soldier in allSoldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }
    }
}
