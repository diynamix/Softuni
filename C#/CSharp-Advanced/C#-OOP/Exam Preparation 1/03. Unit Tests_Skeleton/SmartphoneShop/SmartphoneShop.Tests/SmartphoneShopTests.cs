namespace SmartphoneShop.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartPhone;
        private Shop shop;
        private string modelName = "IPhone 13 Pro Max";
        private int maximumCharge = 100;
        private int capacity = 3;

        [SetUp]
        public void Setup()
        {
            smartPhone = new Smartphone(modelName, maximumCharge);
            shop = new Shop(capacity);
        }

        [Test]
        public void Test_ConstructorIsSettingCorrectly()
        {
            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_NegativeCapacityShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(-1);
            }, "Invalid capacity.");
        }
        
        [Test]
        public void Test_AddSmartphoneShouldWork()
        {
            shop.Add(smartPhone);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_AddSmartphoneThatExistsShouldThrow()
        {
            shop.Add(smartPhone);

            Assert.Throws<InvalidOperationException> (() =>
            {
                shop.Add(smartPhone);
            }, $"The phone model {smartPhone.ModelName} already exist.");

            Assert.Throws<InvalidOperationException> (() =>
            {
                shop.Add(new Smartphone(modelName, 10000));
            }, $"The phone model {smartPhone.ModelName} already exist.");
        }

        [Test]
        public void PhoneCannotBeAdded_WhenCapacityIsFull()
        {
            shop.Add(new Smartphone("1", 1));
            shop.Add(new Smartphone("2", 2));
            shop.Add(new Smartphone("3", 3));

            Assert.Throws<InvalidOperationException> (() =>
            {
                shop.Add(smartPhone);
            }, "The shop is full.");
        }

        [Test]
        public void Test_RemoveSmartphoneShouldWork()
        {
            shop.Add(smartPhone);
            shop.Remove(modelName);

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_RemoveShouldThrow_WhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(modelName);
            }, $"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void Test_TestPhoneShouldReduceBatteryCharge()
        {
            shop.Add(smartPhone);
            shop.TestPhone(modelName, 1);

            Assert.AreEqual(maximumCharge - 1, smartPhone.CurrentBateryCharge);
        }

        [Test]
        public void Test_TestPhoneShouldThrow_WhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, maximumCharge);
            }, $"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void Test_TestPhoneShouldThrow_WhenPhoneIsNotCharged()
        {
            shop.Add(smartPhone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, maximumCharge + 1);
            }, $"The phone model {smartPhone.ModelName} is low on batery.");
        }

        [Test]
        public void Test_ChargePhoneShouldThrow_WhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(modelName);
            }, $"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void Test_ChargePhoneShouldSetBatteryToMax()
        {
            shop.Add(smartPhone);

            shop.TestPhone(modelName, 50);

            shop.ChargePhone(modelName);

            Assert.AreEqual(maximumCharge, smartPhone.CurrentBateryCharge);
        }
    }
}