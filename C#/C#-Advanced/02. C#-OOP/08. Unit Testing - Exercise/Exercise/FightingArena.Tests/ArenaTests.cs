namespace FightingArena.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitializeWorriorsCollection()
        {
            Arena ctorArena = new Arena();

            Assert.IsNotNull(ctorArena.Warriors);
        }

        //[Test]
        //public void WarriorsCollectionShouldBeReadOnly()
        //{
        //    Type collectionType = arena.Warriors.GetType();
        //    Assert.That((arena.Warriors as ICollection<Warrior>).IsReadOnly);
        //    Assert.IsTrue(collectionType == typeof(IReadOnlyCollection<Warrior>));
        //}

        [Test]
        public void EnrollingNonExistingWarriorShouldSuccess()
        {
            Warrior warrior = new Warrior("Peter", 50, 100);

            arena.Enroll(warrior);

            bool isWarriorEnrolled = arena.Warriors.Contains(warrior);

            Assert.IsTrue(isWarriorEnrolled);
        }

        [Test]
        public void EnrollingSameWarriorShouldThrowException()
        {
            Warrior warrior = new Warrior("Peter", 50, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollingWarriorWithTheSameNameShouldThrowException()
        {
            Warrior warrior1 = new Warrior("Peter", 50, 100);
            Warrior warrior2 = new Warrior("Peter", 60, 90);

            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior2);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void CountShouldReturnEnrolledWarriorsCount()
        {
            Warrior warrior1 = new Warrior("Peter", 50, 100);
            Warrior warrior2 = new Warrior("George", 60, 95);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            int expectedCount = 2;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnZeroWhenNoWarriorsAreEnrolled()
        {
            int expectedCount = 0;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FightShouldThrowExceptionWithNonExistingAttacker()
        {
            Warrior warrior1 = new Warrior("Peter", 50, 100);
            Warrior warrior2 = new Warrior("George", 60, 95);

            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(warrior1.Name, warrior2.Name);
            }, $"There is no fighter with name {warrior1.Name} enrolled for the fights!");
        }

        [Test]
        public void FightShouldThrowExceptionWithNonExistingDefender()
        {
            Warrior warrior1 = new Warrior("Peter", 50, 100);
            Warrior warrior2 = new Warrior("George", 60, 95);

            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(warrior1.Name, warrior2.Name);
            }, $"There is no fighter with name {warrior2.Name} enrolled for the fights!");
        }

        [Test]
        public void FightShouldSucceedWhenBothWarriorsExist()
        {
            Warrior warrior1 = new Warrior("Peter", 50, 100);
            Warrior warrior2 = new Warrior("George", 35, 100);

            int w1ExpectedHP = warrior1.HP - warrior2.Damage;
            int w2ExpectedHP = warrior2.HP - warrior1.Damage;

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight(warrior1.Name, warrior2.Name);

            int w1ActualHP = arena.Warriors.First(w => w.Name == warrior1.Name).HP;
            int w2ActualHP = arena.Warriors.First(w => w.Name == warrior2.Name).HP;

            Assert.AreEqual(w1ExpectedHP, w1ActualHP);
            Assert.AreEqual(w2ExpectedHP, w2ActualHP);
        }
    }
}
