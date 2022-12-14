using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002,
                "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
            //            Output
            //The Documents in the Case - 1930
            //The Documents in the Case - 2002
            //Animal Farm - 2003

            Console.WriteLine();
            Console.WriteLine("Sorted by external Comparer:");
            var books = libraryTwo.ToArray();
            Array.Sort(books, new BookComparator());
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
            //            Output
            //Animal Farm - 2003
            //The Documents in the Case - 2002
            //The Documents in the Case - 1930
        }
    }
}