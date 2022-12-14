namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book defBook;
        private string defBookName;
        private string defBookAuthor;

        [SetUp]
        public void SetUp()
        {
            defBookName = "The Lord of the Rings";
            defBookAuthor = "J. R. R. Tolkien";
            defBook = new Book(defBookName, defBookAuthor);
        }

        // Constructor
        [Test]
        public void ConstructorShouldInitializeBookNameCorrectly()
        {
            string expectedBookName = defBookName;
            string actualBookName = defBook.BookName;

            Assert.AreEqual(expectedBookName, actualBookName);
        }

        [Test]
        public void ConstructorShouldInitializeAuthorNameCorrectly()
        {
            string expectedName = defBookAuthor;
            string actualName = defBook.Author;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ConstructorShouldInitializeFootNoteDictionary()
        {
            Type bookType = defBook.GetType();

            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            object fieldValue = dictFieldInfo.GetValue(this.defBook);

            Assert.IsNotNull(fieldValue);
        }

        // FootnoteCount
        [Test]
        public void CountShouldReturnZeroWhenNoFootNotesAdded()
        {
            int expectedCount = 0;
            int actualCount = defBook.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnCorrectCountWhenFootNotesAdded()
        {
            int expectedCount = 2;
            for (int i = 0; i < expectedCount; i++)
            {
                defBook.AddFootnote(i, i.ToString());
            }

            int actualCount = defBook.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        // BookName
        [TestCase("The Lion, the Witch and the Wardrobe")]
        [TestCase("1")]
        [TestCase("   ")]
        public void BookNameShouldSetCorrectValues(string bookName)
        {
            Book book = new Book(bookName, "Author");

            string expectedBookName = bookName;
            string actualBookName = book.BookName;

            Assert.AreEqual(expectedBookName, actualBookName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void BookNameShouldThrowExceptionWhenBookNameIsNullOrEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "Author");
            }, "Invalid BookName!");
        }

        // AuthorName
        [TestCase("C. S. Lewis")]
        [TestCase("1")]
        [TestCase("   ")]
        public void AuthorNameShouldSetCorrectValues(string authorName)
        {
            Book book = new Book("Book name", authorName);

            string expectedAuthorName = authorName;
            string actualAuthorName = book.Author;

            Assert.AreEqual(expectedAuthorName, actualAuthorName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorNameShouldThrowExceptionWhenAuthorNameNullOrEmpty(string authorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Book name", authorName);
            }, "Invalid Author!");
        }

        // AddFootnote
        [Test]
        public void AddingFootNoteShouldIncreaseCount()
        {
            int expectedCount = 1;
            for (int i = 0; i < expectedCount; i++)
            {
                defBook.AddFootnote(i, i.ToString());
            }

            int actualCount = defBook.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingFootNoteShouldAddKeyInTheDictionary()
        {
            int addedKey = 1;
            defBook.AddFootnote(addedKey, "Random text");

            Type bookType = defBook.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)
                dictFieldInfo.GetValue(defBook);
            bool containsKey = fieldValue.ContainsKey(addedKey);

            Assert.IsTrue(containsKey);
        }

        [Test]
        public void AddingExistingFootNoteShouldThrowException()
        {
            int sameKey = 1;
            defBook.AddFootnote(sameKey, "Random note");
            Assert.Throws<InvalidOperationException>(() =>
            {
                defBook.AddFootnote(sameKey, "Another text");
            }, "Footnote already exists!");
        }

        // FindFootnote
        [Test]
        public void FindFootNoteShouldReturnCorrectTextWhenExisting()
        {
            int footKey = 1;
            string footText = "Text";
            defBook.AddFootnote(footKey, footText);

            string expectedResult = $"Footnote #{footKey}: {footText}";
            string actualResult = defBook.FindFootnote(footKey);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindFootNoteShouldThrowExceptionIfThereAreFootNotesButPassedKeyDoesNotExist()
        {
            int footKey = 1;
            string footText = "Text";
            defBook.AddFootnote(footKey, footText);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defBook.FindFootnote(999);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void FindFootnoteShouldThrowExceptionIfThereAreNoFootNotesAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defBook.FindFootnote(1);
            }, "Footnote doesn't exists!");
        }

        // AlterFootNote
        [Test]
        public void AlterFootnoteShouldChangeTextWhenFootNoteExists()
        {
            int footKey = 1;
            string footText = "Text";
            defBook.AddFootnote(footKey, footText);

            string expectedText = "New text";
            defBook.AlterFootnote(footKey, expectedText);

            Type bookType = defBook.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)
                dictFieldInfo.GetValue(defBook);

            string actualText = fieldValue[footKey];
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void AlterFootnoteShouldThrowExceptionIfThereAreFootNotesButPassedKeyDoesNotExist()
        {
            int footKey = 1;
            string footText = "Text";
            defBook.AddFootnote(footKey, footText);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defBook.AlterFootnote(999, "New invalid text");
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootNoteShouldThrowExceptionIfThereAreNoFootNotesAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defBook.AlterFootnote(1, "Invalid text");
            }, "Footnote doesn't exists!");
        }
    }
}