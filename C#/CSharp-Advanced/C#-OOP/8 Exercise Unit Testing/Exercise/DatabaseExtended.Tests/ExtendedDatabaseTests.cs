namespace DatabaseExtended.Tests
{
    using System;
    using NUnit.Framework;
    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private int peopleCount;

        [SetUp]
        public void Setup()
        {
            peopleCount = 15;
            Person[] people = GeneratePeople(peopleCount);
            db = new Database(people);
        }

        [Test]
        public void Constructor_CannotTakeMoreThan16People()
        {
            peopleCount = 17;
            Person[] people = GeneratePeople(peopleCount);
            Assert.Throws<ArgumentException>(() =>
            {
                db = new Database(people);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void Add_IncreasesTheCollectionCount()
        {
            db.Add(new Person(100, "Peter"));
            Assert.AreEqual(peopleCount + 1, db.Count);
        }

        [Test]
        public void Add_CannotAddPersonWithExistingName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(16, "A"));
            }, "There is already user with this username!");
        }

        [Test]
        public void Add_CannotAddPersonWithExistingID()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(1, "Peter"));
            }, "There is already user with this Id!");
        }

        [Test]
        public void Add_CannotExceedMaximumArrayCount()
        {
            db.Add(new Person(16, "Peter"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(17, "George"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Add_AddsPersonToTheCollection()
        {
            Person person = new Person(16, "Peter");
            db.Add(person);
            Person expected = db.FindById(16);
            Assert.AreEqual(person, expected);
        }

        [Test]
        public void Remove_RemovesLastPersonFromTheCollection()
        {
            Person person = new Person(16, "Peter");
            db.Add(person);
            db.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("Peter");
            }, "No user is present by this username!");
        }

        [Test]
        public void Remove_CantFunctionOnEmptyCollection()
        {
            db = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void Remove_DecreasesTheCollectionCount()
        {
            int expectedCount = peopleCount - 1;
            db.Remove();
            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void FindByUsername_ThrowsExceptionIfUsernameNotPresent()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("Peter");
            }, "No user is present by this username!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_UserCantBeNull(string username)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(username);
            }, "Username parameter is null!");
        }

        [Test]
        public void FindByUsername_ReturnsTheCorrectPerson()
        {
            Person person = db.FindByUsername("A");
            Assert.AreEqual("A", person.UserName);
        }

        [Test]
        public void FindById_ReturnsTheCorrectPerson()
        {
            Person person = db.FindById(1);
            Assert.AreEqual(1, person.Id);
        }

        [Test]
        public void FindById_IdMustBePositiveNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-1);
            }, "Id should be a positive number!");
        }

        [TestCase(0)]
        [TestCase(16)]
        public void FindById_ThrowsExceptionIfNonExistingIdIsPassed(int id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(id);
            }, "No user is present by this ID!");
        }

        private Person[] GeneratePeople(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(i + 1, ((char)('A' + i)).ToString());
            }
            return people;
        }
    }
}