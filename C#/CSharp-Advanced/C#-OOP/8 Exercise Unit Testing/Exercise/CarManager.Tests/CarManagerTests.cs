namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string DefaultMake = "Mercedes-Benz";
        private const string DefaultModel = "GLE SUV";
        private const double DefaultFuelConsumption = 8.3;
        private const double DefaultFuelCapacity = 100.00;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);
        }

        [Test]
        public void Constructor_CreatesACarProperly()
        {
            Assert.AreEqual(DefaultModel, car.Model, "Constructor: Model error");
            Assert.AreEqual(DefaultFuelConsumption, car.FuelConsumption, "Constructor: Consumption error");
            Assert.AreEqual(DefaultMake, car.Make, "Constructor: Make error");
            Assert.AreEqual(DefaultFuelCapacity, car.FuelCapacity, "Constructor: Capacity error");
            Assert.AreEqual(car.FuelAmount, 0, "Constructor: Amount error");
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropertyMake_CantBeNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropertyModel_CantBeNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(DefaultMake, model, DefaultFuelConsumption, DefaultFuelCapacity);
            });
        }

        [TestCase(0.0)]
        [TestCase(-1)]
        public void PropertyFuelConsumption_CantBeZeroOrNegative(double fuelConsuption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(DefaultMake, DefaultModel, fuelConsuption, DefaultFuelCapacity);
            });
        }

        [TestCase(0.0)]
        [TestCase(-1)]
        public void PropertyFuelCapacity_CantBeZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void PropertyFuelAmount_CantBeNegative()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(20);
            });
        }

        [TestCase(0.0)]
        [TestCase(-1.0)]
        public void Refuel_FuelAmountCantBeZeroOrNegative(double amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(amount);
            });
        }

        [TestCase(1.0)]
        [TestCase(15.38)]
        public void Refuel_IncreasesCorrectlyTheFuelAmount(double fuel)
        {
            double expectedFuelAmount = car.FuelAmount + fuel;
            car.Refuel(fuel);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void Refuel_FuelAmountCantBeHigherThanFuelCapacity()
        {
            double fuel = DefaultFuelCapacity + 1;
            car.Refuel(fuel);
            Assert.AreEqual(DefaultFuelCapacity, car.FuelAmount);
        }


        [TestCase(1)]
        [TestCase(15.38)]
        public void Drive_DecreasesFuelAmountProperly(double distance)
        {
            car.Refuel(50);
            double expectedFuelAmount = car.FuelAmount - (distance / 100 * car.FuelConsumption);
            car.Drive(distance);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }
    }
}