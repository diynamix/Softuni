namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Reflection;
    using System;
    using System.Linq;

    public class Tests
    {
        private UniversityLibrary defLibrary;

        [SetUp]
        public void Setup()
        {
            defLibrary = new UniversityLibrary();
        }

        // Constructor
        [Test]
        public void ConstructorShouldInitializeTextBookList()
        {
            Type teamType = defLibrary.GetType();

            FieldInfo listFieldInfo = teamType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "textBooks");

            object fieldValue = listFieldInfo.GetValue(this.defLibrary);

            Assert.IsNotNull(fieldValue);
        }


        // Catalogue
        [Test]
        public void CatalogueCountShouldBeZeroWhenNoBooksAdded()
        {
            int expectedCount = 0;
            int actualCount = defLibrary.Catalogue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CatalogueShouldReturnCorrectWhenBooksAdded()
        {
            int expectedCount = 2;
            for (int i = 1; i <= expectedCount; i++)
            {
                defLibrary.AddTextBookToLibrary(new TextBook(i.ToString(), (i + 1).ToString(), (i + 2).ToString()));
            }

            int actualCount = defLibrary.Catalogue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        
        // AddTextBookToLibrary
        [Test]
        public void AddTextBookToLibraryShouldIncreaseCount()
        {
            int expectedCount = 2;
            for (int i = 1; i <= expectedCount; i++)
            {
                defLibrary.AddTextBookToLibrary(new TextBook(i.ToString(), (i + 1).ToString(), (i + 2).ToString()));
            }

            int actualCount = defLibrary.Catalogue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddTextBookToLibraryShouldReturnCorrectMessage()
        {
            TextBook textBook = new TextBook("1", "2", "3");
            string msg = defLibrary.AddTextBookToLibrary(textBook);
            string expectedMsg = textBook.ToString();

            Assert.AreEqual(expectedMsg, msg);
        }


        // LoanTextBook
        [Test]
        public void LoanTextBookShouldReturnCorrectTextWhenStudentHasNotTakenTheBookYet()
        {
            string studentName = "Peter";

            TextBook textBook = new TextBook("1", "2", "3");
            defLibrary.AddTextBookToLibrary(textBook);

            string msg = defLibrary.LoanTextBook(1, studentName);

            string expectedMsg = $"{textBook.Title} loaned to {studentName}.";

            Assert.AreEqual(expectedMsg, msg);
        }

        [Test]
        public void LoanTextBookShouldSetCorrectHolderNameWhenStudentHasNotTakenTheBookYet()
        {
            string studentName = "Peter";

            TextBook textBook = new TextBook("1", "2", "3");
            defLibrary.AddTextBookToLibrary(textBook);

            defLibrary.LoanTextBook(1, studentName);

            string expectedHolderName = studentName;
            string actualHolderName = textBook.Holder;

            Assert.AreEqual(expectedHolderName, actualHolderName);
        }

        [Test]
        public void LoanTextBookShouldReturnCorrectTextWhenStudentHasTakenTheBook()
        {
            string studentName = "Peter";

            TextBook textBook = new TextBook("1", "2", "3");
            textBook.Holder = studentName;
            defLibrary.AddTextBookToLibrary(textBook);

            string msg = defLibrary.LoanTextBook(1, studentName);

            string expectedMsg = $"{studentName} still hasn't returned {textBook.Title}!";

            Assert.AreEqual(expectedMsg, msg);
        }


        // ReturnTextBook
        [Test]
        public void ReturnTextBookShouldReturnCorrectText()
        {
            TextBook textBook = new TextBook("1", "2", "3");
            defLibrary.AddTextBookToLibrary(textBook);

            string msg = defLibrary.ReturnTextBook(1);

            string expectedMsg = $"{textBook.Title} is returned to the library.";

            Assert.AreEqual(expectedMsg, msg);
        }
        
        [Test]
        public void ReturnTextBookShouldClearTextBookHolder()
        {
            TextBook textBook = new TextBook("1", "2", "3");
            defLibrary.AddTextBookToLibrary(textBook);

            defLibrary.ReturnTextBook(1);

            string expectedHolderName = string.Empty;
            string actualHolderName = textBook.Holder;

            Assert.AreEqual(expectedHolderName, actualHolderName);
        }
    }
}