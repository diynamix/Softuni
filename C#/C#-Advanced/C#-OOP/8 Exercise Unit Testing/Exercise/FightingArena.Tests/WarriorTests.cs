namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldInitializeWariorName()
        {
            // Arrange
            string expectedName = "Peter";
            Warrior warrior = new Warrior(expectedName, 50, 50);

            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ConstructorShouldInitializeWariorDamage()
        {
            int expectedDamage = 1;
            Warrior warrior = new Warrior("Peter", expectedDamage, 50);

            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [Test]
        public void ConstructorShouldInitializeWariorHP()
        {
            int expectedHP = 0;
            Warrior warrior = new Warrior("Peter", 50, expectedHP);

            int actualHP = warrior.HP;
            Assert.AreEqual(expectedHP, actualHP);
        }

        [TestCase("Peter")]
        [TestCase("P")]
        [TestCase("Very very very long name")]
        public void NameSetterShouldSetValueWithValidName(string name)
        {
            Warrior warrior = new Warrior(name, 20, 50);

            string expectedName = name;
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        public void NameSetterShouldThrowExceptionWithEmptyOrWhiteSpaceName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 50, 100);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(50)]
        [TestCase(10000000)]
        [TestCase(1)]
        public void DamageSetterShouldSetValueWithValidDamage(int damage)
        {
            Warrior warrior = new Warrior("Peter", damage, 50);

            int expectedDamage = damage;
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(-50)]
        [TestCase(-1)]
        [TestCase(0)]
        public void DamageSetterShouldThrowExceptionWithZeroOrNegativeDamage(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Peter", damage, 50);
            }, "Damage value should be positive!");
        }

        [TestCase(50)]
        [TestCase(1)]
        [TestCase(0)]
        public void HPSetterShouldSetValueWithValidHP(int hp)
        {
            Warrior warrior = new Warrior("Peter", 50, hp);

            int expectedHP = hp;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedHP, actualHP);
        }

        [TestCase(-50)]
        [TestCase(-1)]
        public void HPSetterShouldThrowExceptionWithNegativeHP(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Peter", 50, hp);
            }, "HP should not be negative!");
        }


        // Attack()
        [Test]
        public void SuccessAttackingWorrierNoKill()
        {
            // arrange
            int w1Damage = 50;
            int w1HP = 100;
            int w2Damage = 30;
            int w2HP = 100;
            Warrior w1 = new Warrior("Peter", w1Damage, w1HP);
            Warrior w2 = new Warrior("George", w2Damage, w2HP);

            // Act
            w1.Attack(w2);

            int w1ExpectedHp = w1HP - w2Damage;
            int w2ExpectedHp = w2HP - w1Damage;

            int w1ActualHp = w1.HP;
            int w2ActualHp = w2.HP;

            // Assert
            Assert.AreEqual(w1ExpectedHp, w1ActualHp);
            Assert.AreEqual(w2ExpectedHp, w2ActualHp);
        }

        [Test]
        public void SuccessAttackingWorrierWithKill()
        {
            // arrange
            int w1Damage = 50;
            int w1HP = 100;
            int w2Damage = 30;
            int w2HP = 31;
            Warrior w1 = new Warrior("Peter", w1Damage, w1HP);
            Warrior w2 = new Warrior("George", w2Damage, w2HP);

            // Act
            w1.Attack(w2);

            int w1ExpectedHp = w1HP - w2Damage;
            int w2ExpectedHp = 0;

            int w1ActualHp = w1.HP;
            int w2ActualHp = w2.HP;

            // Assert
            Assert.AreEqual(w1ExpectedHp, w1ActualHp);
            Assert.AreEqual(w2ExpectedHp, w2ActualHp);
        }

        [Test]
        public void AttackingShouldThrowExceptionWhenAttackerHPIsBelowMin()
        {
            // arrange
            int w1Damage = 50;
            int w1HP = 30;
            int w2Damage = 30;
            int w2HP = 100;
            Warrior w1 = new Warrior("Peter", w1Damage, w1HP);
            Warrior w2 = new Warrior("George", w2Damage, w2HP);

            // Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                w1.Attack(w2);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void AttackingShouldThrowExceptionWhenDefenderHPIsBelowMin()
        {
            // arrange
            int w1Damage = 50;
            int w1HP = 40;
            int w2Damage = 30;
            int w2HP = 30;
            Warrior w1 = new Warrior("Peter", w1Damage, w1HP);
            Warrior w2 = new Warrior("George", w2Damage, w2HP);

            // Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                w1.Attack(w2);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void AttackingShouldThrowExceptionWhenAttackerHPIsBelowDefenderDamage()
        {
            // arrange
            int w1Damage = 50;
            int w1HP = 45;
            int w2Damage = 46;
            int w2HP = 100;
            Warrior w1 = new Warrior("Peter", w1Damage, w1HP);
            Warrior w2 = new Warrior("George", w2Damage, w2HP);

            // Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                w1.Attack(w2);
            }, "You are trying to attack too strong enemy");
        }
    }
}