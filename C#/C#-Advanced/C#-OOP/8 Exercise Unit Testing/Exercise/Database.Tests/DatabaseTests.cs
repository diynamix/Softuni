namespace Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defDb;

        // Runsd before every test
        [SetUp]
        public void Setup()
        {
            defDb = new Database();
        }

        // Valid cases (1 Main Case + 2 Edge cases
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldInitializeDataWithCorrectCount(int[] data)
        {
            // Arrange

            // Act
            Database db = new Database(data);

            // Assert
            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        // 1 Main Invalid Case + 1 Edge Ivnalid Case
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void ConstructorShouldThrowExceptionWhenInputDataIsAbove16Count(int[] data)
        {
            // AAA
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);

            }, "Array's capacity must be exactly 16 integers!");
        }

        // We will assume taht Fetch() method is working just fine!
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddElementsIntoDataField(int[] data)
        {
            Database db = new Database(data);

            int[] expectedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CountShouldReturnCorrectCount(int[] data)
        {
            // Arrange
            Database db = new Database(data);

            // Act
            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        // Assume count property is tested and works fine!
        [Test]
        public void AddingElementsShouldIncreaseCount()
        {
            int expectedCount = 5;
            // Arange + Act
            for (int i = 1; i <= expectedCount; i++)
            {
                this.defDb.Add(i);
            }

            int actualCount = this.defDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingElementsShouldAddThemToTheDataCollection()
        {
            int[] expectedData = new int[5];
            // Arange + Act
            for (int i = 1; i <= 5; i++)
            {
                defDb.Add(i);
                expectedData[i - 1] = i;
            }

            int[] actualData = defDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void AddingMoreThan16ElementsShouldThrowAnException()
        {
            // Adding elements to the full capacity
            for (int i = 1; i <= 16; i++)
            {
                defDb.Add(i);
            }

            // Full capacity
            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemovingElementsShouldDecreaseCount()
        {
            int initialCount = 5;
            // Arange + Act
            for (int i = 1; i <= initialCount; i++)
            {
                defDb.Add(i);
            }

            int removeCount = 2;
            // Arange + Act
            for (int i = 1; i <= removeCount; i++)
            {
                defDb.Remove();
            }

            int expectedCount = initialCount - removeCount;
            int actualCount = defDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemovingElementsShouldRemoveItFromTheDataCollection()
        {
            int initialCount = 5;
            // Arange + Act
            for (int i = 1; i <= initialCount; i++)
            {
                defDb.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                defDb.Remove();
            }

            int[] expectedData = new int[] { 1, 2, 3 };
            int[] actualData = defDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void RemovShouldThrowExceptionWhenThereAreNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Remove();
            }, "The collection is empty!");
        }

        // Assume constructor works fine!
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RetchShouldReturnCollectionWithElementsInTheDb(int[] data)
        {
            Database db = new Database(data);

            int[] expectedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}
