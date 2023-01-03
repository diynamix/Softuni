using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 15;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(100, 100);
        }

        [Test]
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(15, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeShouldLooseDurabilityPointsAfterEachAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }

            Assert.AreEqual(durabilityPoints - 5, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeShouldThrowException_WhenDurabilityPointsAreZero()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }

        [Test]
        public void Test_AxeShouldThrowException_WhenDurabilityPointsAreNegative()
        {
            axe = new Axe(10, -1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}