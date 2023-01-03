namespace FootballTeam.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    public class Tests
    {
        private FootballTeam defTeam;
        private string defName;
        private int defCapacity;

        [SetUp]
        public void Setup()
        {
            defName = "Arsenal";
            defCapacity = 15;
            defTeam = new FootballTeam(defName, defCapacity);
        }

        // Constructor
        [Test]
        public void ConstructorShouldInitializeNameCorrectly()
        {
            string expectedName = defName;
            string actualName = defTeam.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ConstructorShouldInitializeCapacityCorrectly()
        {
            int expectedCapacity = defCapacity;
            int actualCapacity = defTeam.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void ConstructorShouldInitializePlayersList()
        {
            Type teamType = defTeam.GetType();

            FieldInfo listFieldInfo = teamType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "players");

            object fieldValue = listFieldInfo.GetValue(this.defTeam);

            Assert.IsNotNull(fieldValue);
        }


        // Players
        [Test]
        public void PlayersCountShouldBeZeroWhenNoPlayersAdded()
        {
            int expectedCount = 0;
            int actualCount = defTeam.Players.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void PlayersShouldReturnCorrectWhenPlayersAdded()
        {
            int expectedCount = 2;
            for (int i = 1; i <= expectedCount; i++)
            {
                defTeam.AddNewPlayer(new FootballPlayer(i.ToString(), i, "Goalkeeper"));
            }

            int actualCount = defTeam.Players.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }


        // Name
        [TestCase("Arsenal")]
        [TestCase("1")]
        [TestCase("   ")]
        public void NameShouldSetCorrectValues(string name)
        {
            FootballTeam team = new FootballTeam(name, defCapacity);

            string expectedName = name;
            string actualName = team.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowExceptionWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(name, defCapacity);
            }, "Name cannot be null or empty!");
        }


        // Capacity
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(100)]
        public void CapacityShouldSetCorrectValues(int capacity)
        {
            FootballTeam team = new FootballTeam(defName, capacity);

            int expectedCapacity = capacity;
            int actualCapacity = team.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenLessThan15()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(defName, 14);
            }, "Capacity min value = 15");
        }


        // AddNewPlayer
        [Test]
        public void AddNewPlayerShouldIncreaseCount()
        {
            int expectedCount = 2;
            for (int i = 1; i <= expectedCount; i++)
            {
                defTeam.AddNewPlayer(new FootballPlayer(i.ToString(), i, "Goalkeeper"));
            }

            int actualCount = defTeam.Players.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddNewPlayerShouldReturnCorrectMessage()
        {
            string msg = defTeam.AddNewPlayer(new FootballPlayer("Remi", 1, "Goalkeeper"));
            string expectedMsg = $"Added player Remi in position Goalkeeper with number 1";

            Assert.AreEqual(expectedMsg, msg);
        }

        [Test]
        public void AddNewPlayerShouldReturnWhenCapacityIsFull()
        {
            for (int i = 1; i <= 15; i++)
            {
                defTeam.AddNewPlayer(new FootballPlayer(i.ToString(), i, "Goalkeeper"));
            }

            string msg = defTeam.AddNewPlayer(new FootballPlayer("Remi", 16, "Goalkeeper"));
            string expectedMsg = "No more positions available!";

            Assert.AreEqual(expectedMsg, msg);
        }

        [Test]
        public void AddNewPlayerShouldNotIncreaseCountWhenCapacityIsFull()
        {
            int expectedCount = 15;
            for (int i = 1; i <= expectedCount; i++)
            {
                defTeam.AddNewPlayer(new FootballPlayer(i.ToString(), i, "Goalkeeper"));
            }

            defTeam.AddNewPlayer(new FootballPlayer("Remi", 16, "Goalkeeper"));

            int actualCount = defTeam.Players.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }


        // PlayerScore
        [Test]
        public void PlayerScoreShouldReturnCorrectTextWhenExisting()
        {
            defTeam.AddNewPlayer(new FootballPlayer("Remi", 1, "Goalkeeper"));

            string actualResult = defTeam.PlayerScore(1);
            string expectedResult = $"Remi scored and now has 1 for this season!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void PlayerScoreShouldIncreasePlayersScore()
        {
            FootballPlayer player = new FootballPlayer("Remi", 1, "Goalkeeper");
            defTeam.AddNewPlayer(player);
            defTeam.PlayerScore(1);
            int actualScore = player.ScoredGoals;
            int expectedScore = 1;

            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}