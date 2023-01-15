using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        private static List<Team> teams;

        static void Main(string[] args)
        {
            teams = new List<Team>();

            RunEngine();
        }

        private static void RunEngine()
        {

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string teamName = tokens[1];

                try
                {
                    if (command == "Team")
                    {
                        teams.Add(new Team(teamName));
                    }
                    else if (command == "Add")
                    {
                        Team team = CheckTeam(teamName);

                        Player player = new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));

                        team.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        Team team = CheckTeam(teamName);
                        team.RemovePlayer(tokens[2]);
                    }
                    else if (command == "Rating")
                    {
                        Team team = CheckTeam(teamName);
                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private static Team CheckTeam(string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team == null)
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }
            return team;
        }
    }
}
