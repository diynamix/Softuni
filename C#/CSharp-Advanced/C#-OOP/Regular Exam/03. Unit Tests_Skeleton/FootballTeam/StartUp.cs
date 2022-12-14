namespace FootballTeam
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            FootballTeam team = new FootballTeam("Arsenal", 29);
            team.AddNewPlayer(new FootballPlayer("Remi", 16, "Goalkeeper"));

            System.Console.WriteLine(team.PlayerScore(16));
        }
    }
}
