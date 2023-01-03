using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private Axe axe;
        private int health;
        private int epxperience;

        [SetUp]
        public void Setup()
        {
            health = 10;
            epxperience = 15;
            dummy = new Dummy(health, epxperience);
            deadDummy = new Dummy(-10, 15);
            axe = new Axe(10, 15);
        }

        [Test]
        public void Test_DummyConstructorShouldSetDataProperly()
        {
            Assert.AreEqual(health, dummy.Health);
        }

        [Test]
        public void Test_DummyLoosesHealth_WhenAttacked()
        {
            dummy.TakeAttack(5);

            Assert.AreEqual(health - 5, dummy.Health);
        }

        [Test]
        public void Test_DummyShouldThrowException_WhenAttackedAndHeathIsZero()
        {
            dummy.TakeAttack(health);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void Test_DummyShouldThrowException_WhenAttackedAndHeathIsNegative()
        {
            dummy.TakeAttack(health);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void Test_DummyShouldGiveExperienceWhenDead()
        {
            var dummyExperience = deadDummy.GiveExperience();

            Assert.AreEqual(epxperience, dummyExperience);
        }

        [Test]
        public void Test_DummyGiveExperienceShouldThrowException_WhenDummyIsAlive()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}